#!/usr/bin/env python
# coding: utf-8
import pandas as pd
import datetime
df0=pd.read_csv("data/TrainTimeTable.csv")#所有列车的时刻表数据库
df_trainId=pd.read_excel("data/沪宁线全表.xlsx")#沪宁线上所有的车次表
df_staInfo=pd.read_excel("data/StationInfo.xlsx")#OD为上海站和南京站的站间信息
real_ids=list(df_trainId['车次'])#存储所有的沪宁线上的列车信息
##从所有的时刻表中挑出所有的沪宁线上的高铁列车，并且进行去重
df_final=pd.DataFrame(columns=df0.columns)
for real_id in real_ids:
    df_final=df_final.append(df0[df0['车次']==real_id].drop_duplicates(subset="站序",keep="first"))#根据站序去重并保留重复的第一行

#进行始发站和终点站之间的筛选
##输入的是沪宁线的起点和终点两个站的站名：上海：上海，上海西，上海虹桥
##输入的是沪宁线的起点和终点两个站的站名：南京：南京，南京东
##输出的是从数据库检索的符合条件的所有车次列表
def get_OD_TrainId(station1,station2):
    df=pd.DataFrame(columns=df_final.columns)
    temp1=df_final[df_final["始发站"]==station1]
    df=temp1[temp1["终点站"]==station2]
    temp2=df_final[df_final["始发站"]==station2]
    df=df.append(temp2[temp2["终点站"]==station1])
    return list(set(list(df["车次"])))
#输入的是列车车次号，输出的是该车次经过规格化的时刻表
def format_timeTable(train_id):
    df_down=pd.DataFrame(columns=df_final.columns)#上海到南京方向

    ##注意这里需要根据总的沪宁线沿线所有的车站来进行编码
    df_down["站序"]=df_staInfo["站序"]
    df_down["车次"]=train_id
    
    ##对始发站和终点站进行规格化
    if int(train_id.replace("G",""))%2==0:#如是下行的上海到南京方向
        df_down["始发站"]="上海"
        df_down["终点站"]="南京"
        df_down["站名"]=df_staInfo["站名"]
        origin_station=list(df_staInfo["站名"])
        a=list(df_staInfo["站名"])
    else:
        df_down["始发站"]="南京"
        df_down["终点站"]="上海"
        df_down["站名"]=list(df_staInfo["站名"])[::-1]
        origin_station=list(df_staInfo["站名"])[::-1]
        a=list(df_staInfo["站名"])
        a.reverse()
   
    origin_arr_time=[]
    origin_start_time=[]
    origin_stay_time=[]
    ##查找没有停站的站名,并将其插入
    for i in range(len(list(df_staInfo["站序"]))):
        origin_arr_time.append("不停站")
        origin_start_time.append("不停站")
        origin_stay_time.append("0分钟")
    index=0
    for item in a:
        if item in list(df_final[df_final['车次']==train_id]["站名"]):            
            origin_arr_time[a.index(item)]=list(df_final[df_final['车次']==train_id]["到站时间"])[index]
            origin_start_time[a.index(item)]=list(df_final[df_final['车次']==train_id]["出发时间"])[index]
            origin_stay_time[a.index(item)]=list(df_final[df_final['车次']==train_id]["停留时间"])[index]
            index+=1
    df_down["到站时间"]=origin_arr_time
    df_down["出发时间"]=origin_start_time
    df_down["停留时间"]=origin_stay_time
    

    return df_down

df_standard_HuNing_trainTimeTables=pd.DataFrame(columns=df0.columns)#存储所有的经过规格化的列车时刻表
for train_id in get_OD_TrainId("南京","上海"):#出发站和终点站的限定下的列车车次取得
    df_standard_HuNing_trainTimeTables=df_standard_HuNing_trainTimeTables.append(format_timeTable(train_id))#添加每一车次的时刻表

train_id="G7001"
format_timeTable(train_id)
df_final[df_final['车次']==train_id]["到站时间"]
df_final[df_final['车次']==train_id]

#得到具体某一个车站的时刻表
##输入的是df_standard_HuNing_trainTimeTables["站名"]一个具体站名
##输出的是该站名所对应的时刻表
def get_station_timeTable(station):
    temp=df_standard_HuNing_trainTimeTables[df_standard_HuNing_trainTimeTables["站名"]==station]
    temp[temp["停留时间"]!="0分钟"].sort_values("到站时间")

#将特定车次的时刻表进行插值，就算是不停站的情况，也有对应的车站到达时刻
##输入的是列车车次
##输出的是经过插值后的时间列表
def get_real_time(train_id):
    staytime=list(df_standard_HuNing_trainTimeTables[df_standard_HuNing_trainTimeTables["车次"]==train_id]["停留时间"])
    realstaytime=[]
    for item in staytime:
        realstaytime.append(item.replace("分钟",""))
    chufashijians=list(df_standard_HuNing_trainTimeTables[df_standard_HuNing_trainTimeTables["车次"]==train_id]["出发时间"])
    chufashijians_noStop_index=[]##存储不停站的索引
    for item in chufashijians:
        if item!="不停站":
            chufashijians_noStop_index.append(chufashijians.index(item))

    #站间距的计算 
    if int(train_id.replace("G",""))%2==0:#如是下行的上海到南京方向
        stations_distance=list(df_staInfo["里程（千米）"])
    else:#计算上行(南京->上海)的站公里桩 
        stations_distance=list(df_staInfo["里程（千米）"])
        up_station_distance=[]
        for i in range(0,len(stations_distance)-1):
            up_station_distance.append(stations_distance[i+1]-stations_distance[i])
        up_station_distance.reverse()
        up_station_kmFlag=[0]
        sum_temp=0
        for i in up_station_distance:
            sum_temp=sum_temp+i
            up_station_kmFlag.append(sum_temp)
        stations_distance=up_station_kmFlag
           
    #时间的分摊
    real_time=[]
    index=-1
    percent_index=0
    for item in chufashijians:
        if item!="不停站":
            real_time.append(datetime.datetime.strptime(item, "%H:%M").strftime("%H:%M:%S"))
            index+=1
        else:
            if staytime[chufashijians_noStop_index[index]]=="----":
                stay=0
            else:
                stay=int(realstaytime[chufashijians_noStop_index[index]])
            shijian1=datetime.datetime.strptime(chufashijians[chufashijians_noStop_index[index]],"%H:%M")+datetime.timedelta(minutes=stay)#目前的时间基点   
            shijian2=datetime.datetime.strptime(chufashijians[chufashijians_noStop_index[index+1]],"%H:%M")#下一个时间基点
            station1_instance=stations_distance[chufashijians_noStop_index[index]]
            station2_instance=stations_distance[chufashijians_noStop_index[index+1]]
            #基于目前基点的时间比例
            times_percent=(stations_distance[percent_index]-station1_instance)/(station2_instance-station1_instance)
            #基于目前基点的时间增量
            time_delta=(shijian2-shijian1)*times_percent
            real_time.append((shijian1+time_delta).strftime("%H:%M:%S"))
        percent_index+=1
    return real_time

#建立车次、站序和时刻表对应的df
df_id_chufashijian=pd.DataFrame(columns=["车次","调整出发时间","站序"])
zhanxu=range(1,22)
for idx in list(set(list(df_standard_HuNing_trainTimeTables["车次"]))):
    real_time=get_real_time(idx)
    df_temp=pd.DataFrame(columns=["车次","调整出发时间"])
    df_temp["调整出发时间"]=real_time
    df_temp["车次"]=idx
    df_temp["站序"]=zhanxu    
    df_id_chufashijian=df_id_chufashijian.append(df_temp)

#将调整后的时间df和原有的df合并
df_standard_HuNing_trainTimeTables=df_standard_HuNing_trainTimeTables.merge(df_id_chufashijian,how="left",on=["车次","站序"])
#删除原有的不符合要求的出发时间列，并将调整出发时间列重命名为出发时间
df_start_time=df_standard_HuNing_trainTimeTables["调整出发时间"]
df_standard_HuNing_trainTimeTables=df_standard_HuNing_trainTimeTables.drop(["出发时间","调整出发时间"],axis=1)
df_standard_HuNing_trainTimeTables.insert(4,"出发时间",df_start_time)
df_standard_HuNing_trainTimeTables[df_standard_HuNing_trainTimeTables["车次"]=="G7001"]

##将规格化的相应的起始站和终点站之间所有车次的时刻表进行规格化
##将规格化的数据按照车次和站序进行排序后导出
df_standard_HuNing_trainTimeTables.sort_values(["车次","站序"]).to_csv("data/OD为上海站和南京站的所有列车时刻表信息.csv",encoding='gb2312',index=0)






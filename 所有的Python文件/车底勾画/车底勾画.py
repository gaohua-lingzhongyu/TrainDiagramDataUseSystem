#高华，2019，04.27，这是勾画列车交路的py文件，
#建模一时爽，解模火葬场
# 输入的是一条线上的经过调整的列车时刻表

#%%
import pandas as pd
import datetime,warnings,sys,os
#将字符串转换成时间格式
def string_toDatetime(st):
    return datetime.datetime.strptime(st, "%H:%M:%S")
#输出车次的起点站时间
def get_O_time(checi):
    time=list(df[df["车次"]==checi][df["站序"]==1]["出发时间"])[0]
    return string_toDatetime(time)

#输出车次的终点站时间
def get_D_time(checi):
    time=list(df[df["车次"]==checi][df["站序"]==21]["出发时间"])[0]
    return string_toDatetime(time)

#输出相互勾画的车次的列表，
#up车次是待勾画的车次列表（面试官），down车次是需要和其搭配的车次（面试者）
def get_checi_partners(up_checi,down_checi):
    checi_partners=[]
    down_checi_dynamic=down_checi.copy()
    for checi in up_checi:
        checi_partner=[checi]
        up_D_time=get_D_time(checi)#拿到上行车次的终点站时间
        checi_next=[checi]#存储符合条件的车次,第0个是需要勾的车次
        checi_next_time=[up_D_time]#存储符合条件的车次的出发时间，第0个是需要勾的车次的到达时间
        #寻找能和车次checi勾画的所有车次
        for checi_temp in down_checi_dynamic:#在下行车次里面找出发时间最近，且隔15min的
            down_O_time=get_O_time(checi_temp)
            time_delta=down_O_time-up_D_time#计算时间差
            if (time_delta>datetime.timedelta(minutes=15)):
                checi_next.append(checi_temp)
                checi_next_time.append(get_O_time(checi_temp))
        if checi_next_time[1:]!=[]:#如果存在符合条件的车次
            checi_partner.append(checi_next[checi_next_time.index(min(checi_next_time[1:]))])
            down_checi_dynamic.remove(checi_next[checi_next_time.index(min(checi_next_time[1:]))])#已经被选择的车次，不再参与勾选
        else:
            checi_partner.append("")
        checi_partners.append(checi_partner)
    return checi_partners


#将勾画好的partner列表转化成df
def get_partners_df(partners):
    df_partners=pd.DataFrame(columns=["车次A","与车次A搭配的车次B"])#运行图的车次勾画
    A=[]
    B=[]
    for item in partners:
        A.append(item[0])
        B.append(item[1])
    df_partners["车次A"]=A
    df_partners["与车次A搭配的车次B"]=B
    return df_partners


#判断两个列表是否包含相同的元素，若是返回true，否则返回false
def is_contains_same_element(A,B):
    exit=False
    for item in A:
        if item in B:
            exit=True
            return exit
    return exit


warnings.filterwarnings('ignore')
print("列车车底勾画算法开始运行")

print(os.getcwd())
df=pd.read_excel(r'data\OD为上海站和南京站的所有列车时刻表信息.xlsx')
print("OD为上海站和南京站的所有列车时刻表信息.xlsx\n----------------读取成功")

print("开始计算")
#将所有的列车按照第一站的出发时间进行排序，从小到大
df_time_start_order=df[df["站序"]==1].sort_values(by="出发时间")

#筛选上下行的车次列表
up_checi=[]
down_checi=[]
for checi in list(df_time_start_order["车次"]):
    if int(checi.replace("G",""))%2==0:
        up_checi.append(checi)
    else:
        down_checi.append(checi) 
up_partners=get_checi_partners(up_checi,down_checi)
down_parners=get_checi_partners(down_checi,up_checi)

df_up_partners=get_partners_df(up_partners)
df_down_partners=get_partners_df(down_parners)

#从上行开始计算车底数
trains_up=[]#车底集合
upA_list=list(df_up_partners["车次A"])
upB_list=list(df_up_partners["与车次A搭配的车次B"])
downA_list=list(df_down_partners["车次A"])
downB_list=list(df_down_partners["与车次A搭配的车次B"])



while upA_list!=[]:
    index=0
    train=[]
    while True:
        item=upA_list[index]
        if item not in train:
            train.append(item)
        item_partner=upB_list[upA_list.index(item)]
        train.append(item_partner)
        upA_list.remove(item)#删除该元素
        upB_list.remove(item_partner)
        if item_partner in downA_list:   
            item_partner_partner=downB_list[downA_list.index(item_partner)]
            train.append(item_partner_partner)
            downA_list.remove(item_partner)
            downB_list.remove(item_partner_partner)
            if item_partner_partner in upA_list:
                index=upA_list.index(item_partner_partner)
            else:
                break
        else:
            break
    trains_up.append(train)    
   
#从下行开始计算车底数
trains_down=[]#车底集合
upA_list=list(df_up_partners["车次A"])
upB_list=list(df_up_partners["与车次A搭配的车次B"])
downA_list=list(df_down_partners["车次A"])
downB_list=list(df_down_partners["与车次A搭配的车次B"])

while downA_list!=[]:
    index=0
    train=[]
    while True:
        item=downA_list[index]
        if item not in train:
            train.append(item)
        item_partner=downB_list[downA_list.index(item)]
        train.append(item_partner)
        downA_list.remove(item)#删除该元素
        downB_list.remove(item_partner)
        if item_partner in upA_list:   
            item_partner_partner=upB_list[upA_list.index(item_partner)]
            train.append(item_partner_partner)
            upA_list.remove(item_partner)
            upB_list.remove(item_partner_partner)
            if item_partner_partner in downA_list:
                index=downA_list.index(item_partner_partner)
            else:
                break
        else:
            break
    trains_down.append(train) 
    

#将上下行重合的车底进行筛选，筛选出车次多的，注意此处不受上下行的车底数量多少的限制
real_trains=[]
for train_up in trains_up:#拿到上行的一个车底
    flag=0
    for train_down in trains_down:#拿到下行的一个车底
        if is_contains_same_element(train_down,train_up)==True:#如果包含相同的车次号，则说明是同一个车次            
            if len(train_down)>len(train_up):
                real_trains.append(train_down)
                trains_down.remove(train_down)
                flag=1
            else:
                flag=2
    if flag==1:
        trains_up.remove(train_up)
    if flag==2:
        real_trains.append(train_up)
        trains_up.remove(train_up)

real_trains=real_trains+trains_up+trains_down

#去重，计算车底数
ids=[]
final_real_trains=[]
for train in real_trains:
    if train not in final_real_trains:
        final_real_trains.append(train)
    for train_id in train:
        if train_id!="":
            ids.append(train_id)   


l=len(final_real_trains)#车底的数量，矩阵的长度
w=0#一个车最多跑的车次，矩阵的宽度
for train in final_real_trains:
    if len(train)>w:
        w=len(train)
for train in final_real_trains:
    if len(train)<w:
        delta=[""]*(w-len(train))
        final_real_trains[final_real_trains.index(train)]=train+delta

df_method=pd.DataFrame()
index=0
for train in final_real_trains:
    df_method.insert(index,"车底"+str(index+1),train)
    index+=1
print("计算完毕")
df_method.to_excel(r"data\交路勾画方案.xlsx",index=0) 
print("总计需要车底数量为：{}".format(l))
print("交路勾画方案.xlsx\n----------------------------------输出成功")
if input("请按下ok继续")=="ok":
    print("程序已退出")

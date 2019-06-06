#!/usr/bin/env python
# coding: utf-8
#20190518
#高华，建模一时爽，解模火葬场
#本文件主要是将C#中导出的所有列车时刻表原始数据格式化为cplex的读取格式

import pandas as pd
import datetime

df=pd.read_excel(r"OD为上海站和南京站的所有列车时刻表信息.xlsx")
def get_id_time(train_id):
    temp=df[df["车次"]==train_id]
    startTime=list(temp[temp["站序"]==1]["出发时间"])[0]
    endTime=list(temp[temp["站序"]==21]["出发时间"])[0]
    return [startTime,endTime]
def is_up(train_id):
    if(int(train_id[1:])%2==0):#判断是否是上行
        return True
    else:
        return False
train_ids=list(set(df["车次"]))
temp=df[df["车次"]=="G7027"]
startTime=list(temp[temp["站序"]==1]["出发时间"])[0]
endTime=list(temp[temp["站序"]==21]["出发时间"])[0]
df_final=pd.DataFrame(columns=["编号","出发车站","终到车站","出发时间(min)","终到时间(min)"])
for train_id in train_ids:
    time=get_id_time(train_id)
    if(is_up(train_id)):#如果是上行的话
        I=[train_id,"上海","南京",time[0],time[1]]
    else:
         I=[train_id,"南京","上海",time[0],time[1]]
    df_temp=pd.DataFrame(I).T
    df_temp.columns=df_final.columns
    df_final=df_final.append(df_temp)
df_final=df_final.sort_values(by=["出发时间(min)"])
df_final.to_excel(r"初始数据.xlsx",index=0)
print("cplex模型输入数据格式调整结束")
print("-"*30)
print("即将运行规划模型求解引擎\n")







#!/usr/bin/env python
# coding: utf-8
#20190518
# 高华，建模一时爽，解模火葬场
#本文件主要是将C#主程序中调用cplex的求解结果进行格式化
#输出的是C#中窗体可视化的数据格式

import pandas as pd
import numpy as np

#输入一个矩阵判断是否全部为0
##全部为0的返回True
def is_all_zero(array):
    for row in df_array:
        for element in row:
            if element!=0:
                return False
    return True

#获得车次索引列表b
xl=pd.ExcelFile(r"优化交路方案.xlsx")
sheet_used=[]#存储使用的车次
stock_num=[]#存储车底跑的车次数量
indexes_x_y=[]
print("正在读取优化交路方案.xlsx，读取时间较长（"+str(len(xl.sheet_names))+"个sheet，每一个sheet中是一个63*63的矩阵）")
for sheet in xl.sheet_names:
    df=pd.read_excel(r"优化交路方案.xlsx",sheet)
    print(sheet+"读取完毕")
    df_array=df.values
    stock_num.append(sum(sum(df_array[:][2:])))
    if(is_all_zero(df_array)!=True):#说明该车底被使用
        sheet_used.append(sheet)
        index_x_y=[]#存储接续节点索引
        for i in range(df_array.shape[1]):
            for j in range(df_array.shape[0]):
                if(df_array[i][j])!=0:
                    index_x_y.append([i,j])
        indexes_x_y.append(index_x_y)
print("正在格式化交路方案")       
solution=[]#存储方案
for index_x_y in indexes_x_y:
    first_item=[]#存储第一个节点的连接情况
    for item in index_x_y:
        if(item[0]==0 or item[0]==1):
            first_item.append(item)
    for item in first_item:
        solution_temp=[item[0]]#存储一个车底的交路方案
        for item1 in index_x_y:
            if item[1]==item1[0]:#判断节点是否接续
                item=item1#如果接续更新下一个节点
                solution_temp.append(item1[0])#存储连接方案
        solution_temp.append(item[1])#记录最后一个节点
        while (solution_temp[-1] not in [0,1]):#防止原始顺序为乱序的情况
            for item1 in index_x_y:
                if item[1]==item1[0]:#判断节点是否接续
                    item=item1#如果接续更新下一个节点
                    solution_temp.append(item1[0])#存储连接方案
            solution_temp.append(item[1])#记录最后一个节点
        solution.append(solution_temp)
#节点接续数组去重，只是第二个元素到倒数第二个元素       
final_solution=[]
for item in solution:
    temp=[]
    temp.append(item[0])
    middle=item[1:-1]
    middleX=list(set(middle))
    middleX.sort(key=middle.index)
    for element in middleX:
        temp.append(element)
    temp.append(item[-1])
    final_solution.append(temp)
solution=final_solution
        
final_real_trains=[]
for s in solution:
    s_temp=[]
    for index in s:
        if index in [0,1]:
            continue
        else:
            s_temp.append(df.columns[index])
    final_real_trains.append(s_temp)

l=len(final_real_trains)
w=0
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
df_method.to_excel(r"交路勾画方案.xlsx",index=0)
print("交路勾画方案.xlsx输出完毕")


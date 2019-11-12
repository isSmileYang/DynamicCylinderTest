MainForm:
https://github.com/isSmileYang/DynamicCylinder/tree/master/ResultShow/MainForm.JPG
动态油缸试验台的监控试验软件平台
1.WInForm界面
   将试验流程操作尽可能集中在主界面，若需要单独复杂说明的操作试验也建立独立界面，由主界面按钮触发
2.逻辑层C#
利用单例模式，模块化设计测试架构，动态油缸平台为基类，实验参数为枚举类，并将试验操作和界面操作分线程执行
3.数据库MySQL
基于Entity Framwork 6.0架构与逻辑层连接

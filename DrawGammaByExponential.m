%程欣宇，2018年4月14日 参考http://www.360doc.com/content/14/0110/18/15459877_344179498.shtml
clc;
x=1:1:1000;%模拟时间长度，有1000个单位
n=100000000;%模拟采样次数
alpha=1;%要求时间发生alpha次
P=rand(n,alpha);%随机采样n组，每组alpha次的概率是均匀分布的
beta=4;%伽马分布的beta参数
lamda=1/beta;%假设指数分布的lamda参数和伽马分布的beta参数有联系
t=-log(1-P)/lamda;%由概率P计算发生每一次的耗时t
%T=sum(t')';%累积alpha次的耗时T
T=t*4;
span=0.1;%为了方便画图，在时间上做的间隔
z = int32(T/span)+1;%把连续的时间值映射到离散的时间间隔上
m=100;%考虑100个时间单位以内的分布形状
f=zeros(m/span,1);%f是累积频度，用来模拟连续概率分布
for i=1:n
    if (z(i)<m/span)%实际上超过m的可能性也有，但是不画图了
        f( z(i))=f( z(i))+1;%进行累积，临时向右偏移一个span
    end
end
f=f/(n*span);%对f进行归一化，确保其含义为概率密度

plot(0:span:m-span, f);%画图
   
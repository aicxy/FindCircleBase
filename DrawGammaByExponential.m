%�����2018��4��14�� �ο�http://www.360doc.com/content/14/0110/18/15459877_344179498.shtml
clc;
x=1:1:1000;%ģ��ʱ�䳤�ȣ���1000����λ
n=100000000;%ģ���������
alpha=1;%Ҫ��ʱ�䷢��alpha��
P=rand(n,alpha);%�������n�飬ÿ��alpha�εĸ����Ǿ��ȷֲ���
beta=4;%٤���ֲ���beta����
lamda=1/beta;%����ָ���ֲ���lamda������٤���ֲ���beta��������ϵ
t=-log(1-P)/lamda;%�ɸ���P���㷢��ÿһ�εĺ�ʱt
%T=sum(t')';%�ۻ�alpha�εĺ�ʱT
T=t*4;
span=0.1;%Ϊ�˷��㻭ͼ����ʱ�������ļ��
z = int32(T/span)+1;%��������ʱ��ֵӳ�䵽��ɢ��ʱ������
m=100;%����100��ʱ�䵥λ���ڵķֲ���״
f=zeros(m/span,1);%f���ۻ�Ƶ�ȣ�����ģ���������ʷֲ�
for i=1:n
    if (z(i)<m/span)%ʵ���ϳ���m�Ŀ�����Ҳ�У����ǲ���ͼ��
        f( z(i))=f( z(i))+1;%�����ۻ�����ʱ����ƫ��һ��span
    end
end
f=f/(n*span);%��f���й�һ����ȷ���京��Ϊ�����ܶ�

plot(0:span:m-span, f);%��ͼ
   
update users_infor set users_status = 0 where users_status =1 

delete from ��ѧ��Ա��Ϣ��

declare @i int
declare @name nvarchar(16)
declare @num nvarchar(18)
set @i = 1;

while (@i<100)
begin
set @name = '����'+convert(nvarchar,@i)
set @num = '510402199603140'+convert(nvarchar,@i)
insert into	��ѧ��Ա��Ϣ��(����,���֤����,��λ��������,��λ����,������רҵ����ְ��,��ί������,�ִ�)
values(@name,@num,'�Ĵ�ʡ��֦���ж���','�����߼���ѧ','�߼���ʦ','��һ��ί��',1)
set @i = @i+1
end
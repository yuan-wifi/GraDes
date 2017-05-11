update users_infor set users_status = 0 where users_status =1 

delete from 中学人员信息表

declare @i int
declare @name nvarchar(16)
declare @num nvarchar(18)
set @i = 1;

while (@i<100)
begin
set @name = '张三'+convert(nvarchar,@i)
set @num = '510402199603140'+convert(nvarchar,@i)
insert into	中学人员信息表(姓名,身份证号码,单位所在区域,单位名称,拟评审专业技术职务,评委会名称,轮次)
values(@name,@num,'四川省攀枝花市东区','第三高级中学','高级教师','第一评委会',1)
set @i = @i+1
end


declare @i int

set @i = 1

while @i < 101
begin
insert into 中学人员信息表
(
 评审编号,
 单位所在市州,
 单位所在区域,
 评委会名称,
 姓名,
 身份证号码,
 拟评审专业技术职务,
 轮次
)
values
(
 @i,
 '四川省攀枝花市东区',
 '四川省攀枝花市东区第三高级中学',
 '第一学科组',
 '张三',
 '510402199603145569',
 '高级教师',
 1
)
set @i = @i + 1
end







delete 中学人员信息表
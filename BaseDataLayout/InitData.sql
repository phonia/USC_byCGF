use [AthenaData]

go


/* 第一层输入时间线和标准版本、行政区划、产品代码、工业行业代码、组织机构版本、文档版本、项目版本、业务版本*/
/*输入事件源*/


Declare  @sid int;
select @sid=EventTimeID from  EventTimes where EventName='industryCode';
select @sid;

insert into StandardVersions values('行业标准',1,'V1.0',null,@sid) ;

select @sid=EventTimeID from  EventTimes where EventName='ProductStandard';
select @sid;

insert into StandardVersions values('产品标准',1,'V1.0',null,@sid) ;


select @sid=EventTimeID from  EventTimes where EventName='administrative';
select @sid;

insert into StandardVersions values('区划标准',1,'V1.0',null,@sid) ;
go

/*输入大学专业标准*/

insert into Specializeds (Code,SpecialName,Descript) select Code,Name,Descript  from ChinaStandard.dbo.Ac_Specialized;
Update  Specializeds set ParentCode =left(Code,4) where len(Code)>=6;
update Specializeds set ParentCode =left(Code,2) where len(Code)=4;
update Specializeds set ParentCode =null where len(Code)=2;
go


/*输入大学专业父字段*/

declare @st1t int ,@zdt varchar(50);
declare sfft cursor for select distinct p.ID,p.Code from Specializeds as p inner join Specializeds as ad1 on  p.Code=ad1.ParentCode;

open sfft;
fetch next from sfft into @st1t,@zdt;
while (@@FETCH_STATUS=0)
begin
update Specializeds set Parent=@st1t where Specializeds.ParentCode=@zdt;
fetch next from sfft into @st1t,@zdt;
end

close sfft;
deallocate sfft;
go



/*输入administrativeDecode数据*/
insert into Administrativecodes(DivisionCode,RegionName,ParentCode) select DivisionCode,RegionName,ParentCode from ChinaStandard.dbo.Ac_administrativecodes ;
declare @qh int;
select @qh=ID from StandardVersions where StandardVersions.Name='区划标准';
select @qh;
update  Administrativecodes set StandardVersionID=@qh;
go

/*输入administrativeCode父字段*/
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.SacID,p.DivisionCode from Administrativecodes as p inner join Administrativecodes as ad1 on  p.DivisionCode=ad1.ParentCode;

open sff;
fetch next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin

update Administrativecodes set Parent=@st1 where Administrativecodes.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;
go

/*输入行业标准*/

insert into IndustryCodes(code,Name,Descript,ParentCode) select Code,IName,Descript,parent from ChinaStandard.dbo.Ac_IndustryCodes;
declare @qh int;
select @qh=ID from StandardVersions where StandardVersions.Name='行业标准';
select @qh;
update  IndustryCodes set StandardVersionID=@qh;
go

/*输入行业标准父字段*/
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.ID,p.Code from IndustryCodes as p inner join IndustryCodes as ad1 on  p.Code=ad1.ParentCode;

open sff;
fetch next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin
update IndustryCodes set Parent=@st1 where IndustryCodes.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;


go



/*输入产品标准*/

insert into ProductStandards(ProductCode,Name,Descript,measureUnit,ParentCode) select ProductCode,PName,Descript,MeasureUnit, parent from ChinaStandard.dbo.Ac_ProductStandards;
declare @qh int;
select @qh=ID from StandardVersions where StandardVersions.Name='产品标准';
select @qh;
update  ProductStandards set StandardVersionID=@qh;
go

/*输入产品标准父字段*/
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.ID,p.ProductCode from ProductStandards as p inner join ProductStandards as ad1 on  p.ProductCode=ad1.ParentCode;

open sff;
fetch next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin
update ProductStandards set Parent=@st1 where ProductStandards.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;


go

/*输入基础地理信息要素及分类代码*/
insert into GBT_13923_2006s(Code,FeatureName,BussnessVerID) 
            select ChinaStandard.dbo.GBT13923ALL.ClassificationCode,ChinaStandard.dbo.GBT13923ALL.Feature,BussnessVers.ID 
			from ChinaStandard.dbo.GBT13923ALL,BussnessVers 
			where BussnessVers.Name='FirstVer' 
			Order By  ChinaStandard.dbo.GBT13923ALL.ClassificationCode ;
/*输入基础地理信息要素及分类代码父字段*/
declare @Pid int,@ocode varchar(50),@Xid int ;
declare cs cursor for select ID,Code from GBT_13923_2006s;
open cs
fetch next from cs into @Pid,@ocode;
while(@@FETCH_STATUS=0)
begin
  set @Xid=NULL;	
  select @Xid=ID from GBT_13923_2006s where Code=
      case
	     when Right(@ocode,5)='00000' then null
         when Right(@ocode,4)='0000' then left(@ocode,1)+'00000'
		 when Right(@ocode,2)='00' then left(@ocode,2)+'0000'
		 When right(@ocode,2)!='00' then left(@ocode,4)+'00'
	  end
  update GBT_13923_2006s set Parent=@Xid where Code=@ocode;

  fetch next from cs into @Pid,@ocode;
end
  close cs;
  deallocate cs;
go


/*输入用地类型标准*/

insert into Land_Types(Name,Content,[Level],Keys,Type_Code,ParentCode) select Name,Content,[level], Keys,T_ID,Parent from ChinaStandard.dbo.LandType;


/*输入用地标准父字段*/
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.ID,p.Type_Code from Land_Types as p inner join Land_Types as ad1 on  p.Type_Code=ad1.ParentCode;

open sff;
fetch Next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin
update Land_Types set ParentID=@st1 where Land_Types.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;
go


/*项目类型*/
insert into Project_Type values('工程类','以土木工程为主题的项目',null);
insert into Project_Type values('服务类','以服务性质为主体的项目',null);
insert into Project_Type values('产品类','以产品运营为主体的项目',null);
insert into Project_Type values('其他类','未明确的',null);
/*程序商店分类*/
insert into Taskgroups values('办公管理','主要提供办公类软件');
insert into Taskgroups values('电子政务','主要提供点在政务类软件');
insert into Taskgroups values('工程管理','主要提供工程类软件');


/*任务类型*/
declare @tgp int ;
select @tgp=ID from TaskGroups where Name='办公管理';
insert into Task_Type values('行政管理','\Iplugn\guang.dll',@tgp,'landmanage',NULL,null,'myde','v1.0',null,12321);
insert into Task_Type values('征地管理','\Iplugn\guang.dll',@tgp,'landmanage',NULL,null,'myde','v1.1',null,12321);
insert into Task_Type values('工程管理','\Iplugn\guang.dll',@tgp,'landmanage',NULL,null,'myde','v1.2',null,12321);
insert into Task_Type values('安全管理','\Iplugn\guang.dll',@tgp,'landmanage',NULL,null,'myde','v1.3',null,12321)
/*任务状态*/
insert into TaskStates values('计划期间','任务已经计划，但还没有启动','计划');
insert into TaskStates values('执行期间','任务开始执行，但还没有完成','执行');
insert into TaskStates values('验收期间','任务已经完成，但正在验收','验收');
insert into TaskStates values('完成归档','任务已经计划，但还没有启动','归档');

go

/* 组织类型 */
insert into Organization_Type(Ocode,OName,Descript,ParentCode) select OCode,OName,Descript,ParentCode from ChinaStandard.dbo.organizationType;
declare @st1 int ,@zd varchar(50);
declare sff cursor for select distinct p.ID,p.Ocode from Organization_Type as p inner join Organization_Type as ad1 on  p.Ocode=ad1.ParentCode;

open sff;
fetch next from sff into @st1,@zd;
while (@@FETCH_STATUS=0)
begin
update Organization_Type set Parent=@st1 where Organization_Type.ParentCode=@zd;
fetch next from sff into @st1,@zd;
end

close sff;
deallocate sff;
go

/* 组织隶属关系代码*/
insert into Subordinates (Code,Name,Descript) select Code,Name,Descript from ChinaStandard.dbo.Subordinate;

/*用户表极其信息*/
insert into users values('tl001','8888','赵一曼','340103190212012343','good','娇媚');
insert into users values('tl002','8888','赵四','340103190212012343','good','娇媚');
insert into users values('tl003','8888','张三','340103190212012343','good','娇媚');
insert into users values('tl004','8888','李小双','340103190212012343','good','娇媚');
insert into users values('tl005','8888','赵红江','340103190212012343','good','娇媚');
insert into users values('tl006','8888','王医仙','340103190212012343','good','娇媚');
go

declare @Uid int;
select @Uid=users.ID from Users where users.UserName='tl001';
insert into Positions values('总经理',@Uid,'GH001',1,NULL,Null,'zongjingli','this is ','zongshi','guangzhou','100038',Null);
select @Uid=users.ID from Users where users.UserName='tl002';
insert into Positions values('vic经理',@Uid,'GH002',1,NULL,Null,'zonasdgjingli','tadsfis ','adfdshi','guangzhou','243243',Null);
select @Uid=users.ID from Users where users.UserName='tl003';
insert into Positions values('sdas经理',@Uid,'GH003',1,NULL,Null,'zongjingli','gfasd ','zonadsfhi','guangzhou','53423',Null);
select @Uid=users.ID from Users where users.UserName='tl004';
insert into Positions values('adf经理',@Uid,'GH004',1,NULL,Null,'zongjingli','reasdis ','zadsfgshi','guangzhou','42323',Null);


/* 文档类型 */
insert into DocumentTypes values('项目管理','代码','这是测试用的',null);
insert into DocumentTypes values('合同类','草稿','zheyeshiceshi',null);
insert into DocManageStates values('归档','finish');
insert into DocManageStates values('过程文档','progress');
go

declare @vrel int;
select @vrel=EventTimeID from EventTimes where EventName='servceStandard'; 
select @vrel;

insert into BussnessVers values('FirstVer','ver1.0',@vrel);
go

insert into Pro_orgRelateType values('业主单位','业主单位',null);
insert into Pro_orgRelateType values('监理单位','监理的单位',null);
insert into Pro_orgRelateType values('设计单位','设计的单位',null);
insert into Pro_orgRelateType values('施工单位','施工现场单位',null);
insert into Pro_orgRelateType values('供应商','device or material',null);
insert into Pro_orgRelateType values('管理单位','managerUnit',null);
insert into Pro_orgRelateType values('合作单位','coop ',null);

go

declare @ls int;
select @ls=ID from Pro_orgRelateType where Name='业主单位';
select @ls;
insert into Pro_orgRelateType values('建设单位','负责投资建设的单位',@ls);
insert into Pro_orgRelateType values('运营单位','负责运营的单位',@ls);



select @ls=ID from Pro_orgRelateType where Name='供应商';
select @ls;
insert into Pro_orgRelateType values('材料供应商','负责投资建设的单位',@ls);
insert into Pro_orgRelateType values('设备供应商','负责运营的单位',@ls);

go





/*-- 添加组织--*/
declare @ty int;
select @ty=ID from Organization_Type where OName='私营有限责任公司';
select @ty;
insert into Organizations values('716309097','广州市海珠区瑞宝南路11号'     ,'3814221','1993-06-01', null, '广州图之灵',1);
insert into Organizations values('716300987','广州市大元帅府'               ,'3815222','1994-06-02', null , '大元帅府',1);
insert into Organizations values('716301232','广州市软件监理公司'           ,'3815223','1994-06-02', null, '监理',0);
go


/*--填写公司基本信息--*/

declare @tyx int,@evt int,@uid int,@said int;
select @tyx=ID from Organizations where OrganizationCode='716309097';
select @tyx;
select @evt=EventTimeID from EventTimes where TimePoint='2012-01-02';
select @evt;
select @uid=Positions.ID from positions where Positions.Title='总经理';
select @said=Administrativecodes.SacID from Administrativecodes  where Administrativecodes.DivisionCode='440103002103';
insert into OrganizBasics values('Tl001234','广州市瑞南路海珠创意园',@uid,'广州市同一地点','11号大楼','23490万','技术研发','融资租赁',5,3,'海珠区工商局','2018-01-01','2011-11-09','创新使企业的生命',null,1,4,3,@said,1);
go
/* 添加部门职能类型*/
insert into Functions Values('核心职能','描述部门所承担的核心职能','ceshi','ceshi',null);
insert into Functions Values('专业职能','描述部门承担的具体技术职能','是实现职能的技术要求','ceshi',null);
insert into Functions Values('管理职能','描述部门完成专业职能所进行的管理活动职能','就这样吧','zheyang',null);
insert into Functions Values('一般职能','描述部门完成专业和核心职能所需要的一般只能如汇报','文件起草等','看起来',null);
go

/* 添加部门 */

Declare @ty1 int,@dep int;
select @ty1=ID from Organizations where OrganizationCode='716309097';
select @ty1;
insert into Departments values('总经理办公室','总经理办公室标记',null,'这是描述数字','中国人们的清华',1,'取消时间',@ty1,null);

 
go
/*创建部门职能*/
declare @dep int,@fty int;
select @dep=ID from Departments where Name='总经理办公室'
select @dep;
select @fty=ID from Functions where Name='核心职能';
select @fty;
insert into DepartmentFunctions values ('制定公司战略计划',1,@dep,@fty)
insert into DepartmentFunctions values ('实现公司目标计划',1,@dep,@fty)
insert into DepartmentFunctions values ('监督实施计划',1,@dep,@fty)

select @dep=ID from Departments where Descript='总经理办公室'
select @dep;
select @fty=ID from Functions where Name='专业职能';
select @fty;
insert into DepartmentFunctions values ('指挥调度要素',1,@dep,@fty)
insert into DepartmentFunctions values ('控制要素发挥作用',1,@dep,@fty)
insert into DepartmentFunctions values ('激发要素的活力',1,@dep,@fty)

select @dep=ID from Departments where Descript='总经理办公室'
select @dep;
select @fty=ID from Functions where Name='管理职能';
select @fty;
insert into DepartmentFunctions values ('做计划',1,@dep,@fty)
insert into DepartmentFunctions values ('审批',1,@dep,@fty)
insert into DepartmentFunctions values ('决策',1,@dep,@fty)
go

/*创建岗位*/
declare @gw int,@zhe int,@pID int,@spid int;
select @zhe=EventTimeID from EventTimes where TimePoint='2012-01-01';
select @zhe;

select @gw=ID from Departments where Descript='总经理办公室';
select @gw;
insert into Posts values(Null,'总经理岗位',@gw,'负责全面工作','岗位标记',1,null);

select @pID=ID from Posts where Descript='负责全面工作';
select @pID;

select @spid=ID from Specializeds where SpecialName='信息与计算科学';

insert into Postbasics values('总经理','决策公司重大问题','一级','本科','高级管理师',null,@zhe,@spid,@pID);

insert into PositionBasics values('Super','Super','20000','靠脑子','公司办公室',@zhe,@pID,null);

/* second*/
declare @gw1 int,@zhe1 int,@pID1 int ;
select @zhe1=EventTimeID from EventTimes where TimePoint='2012-01-01';
select @zhe1;

select @gw1=ID from Departments where Descript='总经理办公室';
select @gw1;
insert into Posts values('bussboss',@gw,'副总经理','岗位标记',1,null,null);

select @pID1=ID from Posts where Descript='副总经理';
select @pID1;
 
insert into Postbasics values('付总经理','协助决策公司重大问题','二级','本科','高级管理师',null,@zhe1,@spid,@pID1);
insert into PositionBasics values('Super','Super','18000','靠关系','公司办公室' ,@zhe1,@pID1,null);


/* third*/
declare @gw2 int,@zhe2 int,@pID2 int ;
select @zhe2=EventTimeID from EventTimes where TimePoint='2012-01-01';
select @zhe2;

select @gw2=ID from Departments where Descript='总经理办公室';
select @gw2;
insert into Posts values('总工',@gw,'总工岗位','岗位标记',1,null,null);

select @pID2=ID from Posts where Descript='总工岗位';
select @pID2;
 

insert into Postbasics values('总工','决策公司重大技术问题','一级','研究生','高级管理师',null,@zhe2,@spid,@pID2);
insert into PositionBasics values('Super','Super','19000','靠技术','公司办公室' ,@zhe2,@pID2,null);
go
 

/*添加三个岗位职责*/
/*第一岗位第一个职责*/
declare @gwc int,@duid int,@eventtime int, @taskty int,@dfun int;

select @dfun=ID from DepartmentFunctions where Content='制定公司战略计划';
select @dfun;

select @eventtime=EventTimes.EventTimeID from EventTimes where TimePoint='2012-01-01';
select @eventtime;

select @gwc=ID from Posts where Descript='总经理岗位';
select @gwc;

insert into Duties values('总经理的第一个职责','技术的工作','职责标记','做工作','是想方法','这是舍妹你们','注释和标记','又是描述',1,2);


select @duid =ID from duties where Descript='总经理的第一个职责';
select @duid;
select @taskty=ID from Task_Type where TypeName='征地管理';
select @taskty;
insert into authorizationinfoes values(@gwc,@duid,1,'shaojinlin',null);
insert into DutyBasics values('决策管理','全面负责公司的战略决策','采用民主集中制','市场的办法','管理的方式','向董事会汇报',@duid,null,@eventtime,@taskty);

/*第一岗位第二个职责*/

insert into Duties values('管理服务','总经理的第二个职责','职责标记','erty','hgfhf','ghjghj','jhgo','标识',null,@dfun);
select @duid =ID from duties where Descript='总经理的第二个职责';
select @duid;

insert into DutyBasics values('财务管理','全面负责公司的财务政策','采用领导负责','管理的办法','管理的方式','向董事会汇报',@duid,null,@eventtime,@taskty);

/*第一岗位第三个职责
insert into Duties values('总经理的第三个职责','职责标记','士大夫','敢死队','犹太人他','范甘迪','utyty',1,@dfun);
select @duid =ID from duties where Descript='总经理的第三个职责';
select @duid;

insert into DutyBasics values('市场管理','全面负责公司的市场决策','采用民主集中制','市场的办法','管理的方式','向董事会汇报',@duid,null,@eventtime,@taskty);
go
*/
/*第二岗位第一个职责*/
declare @gwc int,@duid int,@eventtime int, @taskty int,@dfun int;

select @dfun=ID from DepartmentFunctions where Content='制定公司战略计划';
select @dfun;
select @eventtime=EventTimes.EventTimeID from EventTimes where TimePoint='2012-01-01';
select @eventtime;

select @gwc=ID from Posts where Descript='副总经理';
select @gwc;
select @taskty=ID from Task_Type where TypeName='征地管理';
select @taskty;
/*
insert into Duties values('副总经理的第一个职责','职责标记',@dfun);
select @duid =ID from duties where Descript='副总经理的第一个职责';
select @duid;
*/
/*
insert into authorizationinfoes values(@gwc,@duid,1,'other',null);
insert into DutyBasics values('协助决策管理','协助公司的战略决策','采用民主集中制','市场的办法','管理的方式','向总经理汇报',@duid,null,@eventtime,@taskty);

/*第二岗位第二个职责*/
insert into Duties values('副总经理的第二个职责','职责标记',@dfun);
select @duid =ID from duties where Descript='副总经理的第二个职责';
select @duid;

insert into DutyBasics values('市场管理','实施公司市场战略','采用民主集中制','市场的办法','管理的方式','向总经理汇报',@duid,null,@eventtime,@taskty);

/*第二岗位第三个职责*/
insert into Duties values('副总经理的第三个职责','职责标记',@dfun);
select @duid =ID from duties where Descript='副总经理的第三个职责';
select @duid;

insert into DutyBasics values('协助后勤管理','协助解决公司后勤补给问题','采用民主集中制','市场的办法','管理的方式','向总经理汇报',@duid,null,@eventtime,@taskty);
go


/*第三岗位第一个职责*/
declare @gwc int,@duid int,@eventtime int,@taskty int,@dfun int;
select @eventtime=EventTimes.EventTimeID from EventTimes where TimePoint='2012-01-01';
select @eventtime;
select @dfun=ID from DepartmentFunctions where Content='制定公司战略计划';
select @dfun;
select @gwc=ID from Posts where Descript='总工岗位';
select @gwc;
select @taskty=ID from Task_Type where TypeName='征地管理';
select @taskty;/*
insert into Duties values('总工的第一个职责','职责标记',@dfun);
select @duid =ID from duties where Descript='总工的第一个职责';
select @duid;

insert into DutyBasics values('技术管理','全面负责公司的技术战略','采用民主集中制','市场的办法','管理的方式','向董事会汇报',@duid,null,@eventtime,@taskty);
/*第三岗位第二个职责*/
insert into Duties values('总工的第二个职责','职责标记',@dfun);
select @duid =ID from duties where Descript='总工的第二个职责';
select @duid;

insert into DutyBasics values('生产管理','全面负责公司的工作任务完成','采用领导负责','管理的办法','管理的方式','向董事会汇报',@duid,null,@eventtime,@taskty);

/*第三岗位第三个职责*/
insert into Duties values('总工的第三个职责','职责标记',@dfun);
select @duid =ID from duties where Descript='总工的第三个职责';
select @duid;

insert into DutyBasics values('科研管理','全面负责公司的市场可积极研发','采用民主集中制','市场的办法','管理的方式','向董事会汇报',@duid,null,@eventtime,@taskty);
*/
*/
/*将岗位付给用户，成为公司雇员 */
declare @us int,@post int,@tim int;
select @us=users.ID from users where ActualName='赵一曼';
select @us;
select @post=ID  from Posts where Descript='总经理岗位'
select @post;
select @tim=EventTimeID from EventTimes Where TimePoint='2012-01-03';
/*
insert into Employees values('zhaoyiman',@us,@post,'Tl001',1,@tim,null);

select @us=users.ID from users where ActualName='赵四';
select @us;
select @post=ID  from Posts where Descript='副总经理'
select @post;
insert into Employees values('zhaosi',@us,@post,'Tl002',1,@tim,null);

select @us=users.ID from users where ActualName='张三';
select @us;
select @post=ID  from Posts where Descript='总工岗位'
select @post;
insert into Employees values('zhangsan',@us,@post,'Tl003',1,@tim,null);
*/
go
Declare @tim int ,@pbase int;
select @tim=EventTimeID from EventTimes where TimePoint='2012-01-07';
select @tim;

/*建立项目管理*/
insert into ProjectBaseManagers values(@tim,'高速公路项目管理根项目','江罗高速公路原始项目',null,'项目属性');
select @pbase=ID from ProjectBaseManagers where ProjectRoot='高速公路项目管理根项目';
select @pbase ;

insert into ProjectBaseManagers values(@tim,'高速公路施工进度控制','江罗高速公路控制',@pbase,'基本项目');
insert into ProjectBaseManagers values(@tim,'根项目基线','施工进度基线',@pbase,'项目测试');
go
/*建立项目数据*/
declare @ty int,@emp int,@basid int;
select @ty=ID from Project_Type where Name='工程类';
select @ty;
select @emp=ID from Employees where Employees.UserID !=null;
select @emp;
select @basid=ID from ProjectBaseManagers where name='江罗高速公路控制';
select @basid;

insert into Projects values('Projecttestone',@ty,'这个项目可不得了，是我们的技术研发的第一步','2012-01-01','2015-01-01',null,@emp,@basid,1,1 );
insert into Projects values('Projecttexttwo',@ty,'这个技术项目的第二个项目，希望你能支持','2012-01-01','2016-01-01',null,@emp,@basid,0,1);
go
/* 建立项目和组织的关系*/

declare @pr int,@pj int,@por int;
select @pr=ID from Pro_orgRelateType Where name='建设单位';
select @pr;
select @pj=ID from projects Where IsBase=1;
select @pj;
select @por=ID from Organizations where Organizations.OrganizationCode='716309097'
select @por;
insert into projectRelateOrganizations values(@pj,@por,@pr);


/* 填写项目内容信息*/

insert  into projectbasics values(@pj,'江罗高速公路','广东省公路建设有限公司','公路的设计、施工、监理',null);
declare @pjj int;
select @pjj=ID from projects Where IsBase=0;
select @pjj;
insert  into projectbasics values(@pjj,'广东省公路建设有限公司','公路的设计、施工、监理','合同文档00123',null);

go

/* 填写任务信息*/
declare @taid int,@tasate int,@prj int;
select @taid=ID from Task_Type where TypeName='征地管理';
select @taid;
select @tasate=ID from TaskStates where State='执行期间';
select @tasate;
select @prj=ID from Projects where Projects.StartTime='2012-01-01';
select @prj;

insert into Tasks values('土地征收','负责土地征收','赵一曼','捻村的征地事务',@taid,@tasate,@prj,null,'2012-08-08','2012-08-08',null);
insert into Tasks values('管线管理','负责管线的变更','赵一曼','捻村的征地事务',@taid,@tasate,@prj,null,'2012-08-08','2013-08-08',null);
insert into Tasks values('经济作物','负责青苗赔偿','赵一曼','捻村的征地事务',@taid,@tasate,@prj,null,'2012-08-08','2013-08-08',null);

go
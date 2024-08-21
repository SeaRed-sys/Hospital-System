USE master
---建库---------------------------------------------------------------------------------------------
GO
CREATE DATABASE MedicineSystem
 CONTAINMENT = NONE
 ON  PRIMARY 
(	NAME = 'MedicineSystem', 
	FILENAME = N'D:\DATA\MedicineSystem.mdf'  
)
 LOG ON 
(	NAME = 'MedicineSystem_log', 
	FILENAME = 'D:\DATA\MedicineSystem_log.ldf' 
 )
 -------创建SQL登录名-------------------------------------------------------
 GO
 USE MedicineSystem
 IF SUSER_ID('SqlLogin1') IS NOT NULL					
	DROP LOGIN SqlLogin1;				
	GO					
CREATE LOGIN SqlLogin1					
		WITH 				
		PASSWORD='haihong0215' 			
		,CHECK_POLICY=OFF			
		,DEFAULT_DATABASE=master;	
 ---1-------------------------------------------------------------------------------------------------
--建表-用户类型：编号，类型名
IF OBJECT_ID('tb_UserType')IS NOT NULL
DROP TABLE tb_UserType
CREATE TABLE tb_UserType
(No int NOT NULL
,TypeName VARCHAR(20) NOT NULL
)
--插入数据-
INSERT INTO tb_UserType
(NO,TypeName)
 VALUES
 (1,'普通用户')
 ,(2,'操作人员')
GO
 ---2-------------------------------------------------------------------------------------------------
--建表-2.用户：用户类型编号，ID号，密码
IF OBJECT_ID('tb_User')IS NOT NULL
DROP TABLE tb_User
CREATE TABLE tb_User
(TypeNo VARCHAR(10) NOT NULL
,IDName VARCHAR(20) NOT NULL
,Password VARCHAR(100)NOT NULL
,IsActivated BIT NOT NULL
,LoginFailCount INT NOT NULL DEFAULT 0
)
--插入数据-登录表
INSERT INTO tb_User
(TypeNo,IDName,Password,IsActivated)
 VALUES('1','3220707001',HASHBYTES('MD5','3220707001'),1)
 ,('2','3220707051',HASHBYTES('MD5','3220707051'),1)
GO
---3--------------------------------------------------------------------------------------------------
--建表-操作人员表（工号，姓名，性别，出生日期，年龄，手机号码，家庭地址）
IF OBJECT_ID('tb_Operator')IS NOT NULL
DROP TABLE tb_Operator
CREATE TABLE tb_Operator(
	NO char(10) PRIMARY KEY NOT NULL,
	UserNo VARCHAR(20) NOT NULL,
	Name varchar(10) NOT NULL,
	Sex varchar(20) NOT NULL,
	Birthday date NOT NULL,
	Age int NULL,
	Phone varchar(20) NULL,
	Address varchar(100) NULL,
	Photo VARBINARY(MAX) NULL
) 
--增加数据
INSERT tb_Operator
(NO ,UserNo,Name,Sex ,Birthday,Age ,Phone ,Address )
VALUES
('3220707051','3220707051','曾海红','女','2003/2/15','21','15605089826','江西赣州')
GO
--------设置密保-------------------------------------------
IF ASYMKEY_ID('ak_MedicineSystem_ForSymKeyCrypto')IS NOT NULL
	DROP ASYMMETRIC KEY ak_MedicineSystem_ForSymKeyCrypto
GO
CREATE ASYMMETRIC KEY ak_MedicineSystem_ForSymKeyCrypto
WITH
ALGORITHM=RSA_2048
ENCRYPTION BY PASSWORD='1qaz@WSX';

IF KEY_ID('sk_MedicineSystem_ForSymKeyCrypto')IS NOT NULL
	DROP SYMMETRIC KEY sk_MedicineSystem_ForSymKeyCrypto
GO
CREATE SYMMETRIC KEY sk_MedicineSystem_ForSymKeyCrypto
WITH
ALGORITHM=AES_128
ENCRYPTION BY  ASYMMETRIC KEY ak_MedicineSystem_ForSymKeyCrypto;
GO
---4--------------------------------------------------------------------------------------------------
--建表-领药人：工号，姓名
IF OBJECT_ID('tb_TakeMedicineMan')IS NOT NULL
DROP TABLE tb_TakeMedicineMan
CREATE TABLE tb_TakeMedicineMan(
	No char(10) PRIMARY KEY NOT NULL,
	Name varchar(100) NOT NULL
)
--增加数据
INSERT tb_TakeMedicineMan
      (No ,Name )
	  VALUES('001','小Siri');
GO
---5--------------------------------------------------------------------------------------------------
--建表-护士：工号，姓名
IF OBJECT_ID('tb_Nurse')IS NOT NULL
DROP TABLE tb_Nurse
CREATE TABLE tb_Nurse(
	No varchar(20) PRIMARY KEY NOT NULL,
	Name varchar(100) NOT NULL
) 
--增加数据
INSERT INTO tb_Nurse
      (No ,Name)
	  VALUES
	   ('101','张小梦')
	  ,('102','王小琪')
	  ,('103','李雪梅')
	  ,('104','叶琴琴')
	  ,('105','韦白雪');
GO
---6--------------------------------------------------------------------------------------------------
--建表-药库：编号，名称
IF OBJECT_ID('tb_MedicineStorage')IS NOT NULL
DROP TABLE tb_MedicineStorage
CREATE TABLE tb_MedicineStorage(
	No  char(20) PRIMARY KEY NOT NULL,
	Name varchar(20)  NOT NULL,
)
INSERT INTO tb_MedicineStorage
      (No ,Name)
	  VALUES('1111','仁和大药库')
GO
---7--------------------------------------------------------------------------------------------------
--建表-药房：编号，名称
IF OBJECT_ID('tb_MedicineHall')IS NOT NULL
DROP TABLE tb_MedicineHall
CREATE TABLE tb_MedicineHall(
	No  char(20) PRIMARY KEY NOT NULL,
	Name varchar(20)  NOT NULL,
)
INSERT INTO tb_MedicineHall
      (No ,Name)
	  VALUES('11110','仁和药房')
GO
---8--------------------------------------------------------------------------------------------------
--建表-病区：编号，名称
IF OBJECT_ID('tb_Ward')IS NOT NULL
DROP TABLE tb_Ward
CREATE TABLE tb_Ward(
	No  int PRIMARY KEY NOT NULL,
	Name varchar(20)  NOT NULL,
)
INSERT INTO tb_Ward
      (No ,Name)
	  VALUES(1,'病区一'),
	  (2,'病区二'),
	  (3,'病区三'),
	  (4,'病区四'),
	  (5,'病区五')
GO
---9--------------------------------------------------------------------------------------------------
--建表-病区护士表：病区号，护士号
IF OBJECT_ID('tb_WardNurse')IS NOT NULL
DROP TABLE tb_WardNurse
CREATE TABLE tb_WardNurse(
	WordNo int Not NULL,
	NurseNo int Not NULL
) 
--增加数据
INSERT tb_WardNurse
      (WordNo ,NurseNo)
	  VALUES
	  ('111101','101'),('111102','102'),('111103','103'),('111104','104'),('111105','105') 
GO
---10--------------------------------------------------------------------------------------------------
--建表-药品：编号，名称，名称拼音，规格，药品作用，药剂类别，药品单位，药品性质，药品剂型，生产批号，生产单位，生产日期，有效期，使用期，注册单位，实际价，批发价，零售价
IF OBJECT_ID('tb_Medicine')IS NOT NULL
DROP TABLE tb_Medicine
CREATE TABLE tb_Medicine(
	No char(10) PRIMARY KEY NOT NULL,
	Name varchar(20) NOT NULL,
	NamePinyin varchar(50) NOT NULL,
	Standard varchar(20) NOT NULL,
	FunctionWork varchar(300)  NULL,
	Type varchar(10) NOT NULL,
	Unit varchar(10)  NULL,
	MedicinePropert varchar(20) NULL,---药品性质
	MedicineForm varchar(20) NULL, ---药品剂型
	BatchNo varchar(20) NULL,
	BatchUnit varchar(50) NULL,
	BatchDate Date  NULL,
	LifeSpan varchar(10) NULL,
	UseDate Date  NULL,
	LoginUnit varchar(50) NULL,
	Price1 money  NULL,
	Price2 money  NULL,
	Price3 money  NULL,
	Photo VARBINARY(MAX) NULL
) 
--增加数据-
INSERT tb_Medicine (No ,
	Name ,NamePinyin ,Standard ,FunctionWork,Type ,Unit ,MedicinePropert,MedicineForm,BatchNo ,BatchUnit ,BatchDate ,LifeSpan ,
	UseDate ,LoginUnit ,Price1 ,Price2,Price3 ) 
VALUES
 ('M0001','阿莫西林','amoxilin','0.25g*24粒','阿莫西林具有杀菌抗炎的功效，通常用于由细菌感染引起的炎症治疗，如治疗伤寒、上呼吸道感染和胃肠道疾病等，并可用于预防感染。','西药','盒','内服药','胶囊','20230101','某制药有限公司','2023/01/01','24个月','2025/01/01','国家药品监督管理局','10','8','15')
,('M0002','感冒清热颗粒','ganmaoqingrekeli','10g*10袋','感冒清热颗粒是一种中药制剂，主要用于缓解感冒引起的发热、头痛、咽喉肿痛和咳嗽等症状，具有清热解毒、消炎镇痛、抗病毒和免疫调节等作用。','中成药','盒','内服药','颗粒剂','20230205','某中药制药厂','2023/02/05','18个月','2024/08/05','国家药品监督管理局','15','12','20')
,('M0003','布洛芬','buluofen','0.3g*20片','布洛芬为解热镇痛类，非甾体抗炎药，通过抑制环氧化酶，减少前列腺素的合成，产生镇痛、抗炎作用；通过下丘脑体温调节中枢而起解热作用。用于缓解轻至中度疼痛如头痛、关节痛、偏头痛、牙痛、肌肉痛、神经痛、痛经。也用于普通感冒或流行性感冒引起的发热。','西药','盒','内服药','胶囊','20230310','某制药股份有限公司','2023/03/10','36个月','2026/03/10','国家药品监督管理局','20','16','25')
,('M0004','硝苯地平','xiaobendiping','10mg*30片','硝苯地平：是一种二氢吡啶类钙拮抗剂，用于预防和治疗冠心病心绞痛，特别是变异型心绞痛和冠状动脉痉挛所致心绞痛。对顽固性、重度高血压也有较好疗效。','西药','盒','内服药','片剂','20230420','某生物科技公司','2023/04/20','24个月','2025/04/20','国家药品监督管理局','30','24','38')
,('M0005','罗红霉素','luohongmeisu','150mg*12粒','罗红霉素片：是一种广谱抗生素，具有消炎、杀菌的功效，主要用于治疗呼吸道感染、皮肤软组织感染和泌尿生殖系统感染等','西药','盒','内服药','颗粒剂','20230515','某制药集团','2023/05/15','30个月','2025/11/15','国家药品监督管理局','40','32','50')
,('M0006','硫酸氢氯吡格雷','liusuanqinglvpigelei','75mg*7片','硫酸氢氯吡格雷：是一种抗血小板药物，主要用于预防动脉粥样硬化血栓形成，如近期心肌梗死、近期缺血性中风、确诊的外周动脉疾病和急性冠状动脉综合征等。','西药','盒','内服药','片剂','20230608','某医药有限公司','2023-06-08','24个月','2025-06-08','国家药品监督管理局','80','64','100')
,('M0007','六味地黄丸','liuweidihuangwan','200丸/瓶','六味地黄丸：为补益剂，具有滋阴补肾之功效。用于肾阴亏损，头晕耳鸣，腰膝酸软，骨蒸潮热，盗汗遗精，消渴。','中成药','瓶','内服药','丸剂','20230722','某中药制药有限公司','2023/07/22','24个月','2025/07/22','国家药品监督管理局','50','40','65')
,('M0008','氨茶碱','ancaijian','0.1g*100片','氨茶碱：主要用于支气管哮喘、喘息型支气管炎、阻塞性肺气肿等缓解喘息症状；也可用于心源性肺水肿引起的哮喘。','西药','瓶','注射药','注射剂','20230810','某制药股份有限公司','2023/08/10','36个月','2026/08/10','国家药品监督管理局','60','48','75')
,('M0009','格列齐特','gelieqite','80mg*30片','格列齐特：是第二代磺脲类降血糖药，作用较强，其机理是选择性地作用于胰岛β细胞，促进胰岛素分泌，并提高进食葡萄糖后的胰岛素释放。','西药','盒','内服药','片剂','20230905','某制药有限公司','2023/09/05','24个月','2025/09/05','国家药品监督管理局','70','56','88')
,('M0010','奥美拉唑','ameilacuo','20mg*14粒','奥美拉唑：主要用于十二指肠溃疡和卓-艾综合征，也可用于胃溃疡和反流性食管炎；静脉注射可用于消化性溃疡急性出血的治疗。','西药','盒','内服药','胶囊','20231010','某制药厂','2023/10/10','24个月','2025/10/10','国家药品监督管理局','45','36','55')
,('M0011','复方丹参片','fufangdansenpian','60片/瓶','复方丹参片：具有活血化瘀，理气止痛之功效。主治气滞血瘀所致的胸痹，症见胸闷、心前区刺痛；冠心病心绞痛见上述证候者。','中成药','瓶','内服药','片剂','20231115','某中药制药企业','2023/11/15','36个月','2026/11/15','国家药品监督管理局','65','52','80')
,('M0012','氯雷他定片','lvleitadingpian','10mg*12片','氯雷他定片：主要用于缓解过敏性鼻炎有关的症状，如喷嚏、流涕、鼻痒、鼻塞以及眼部痒及烧灼感。口服药物后，鼻和眼部症状及体征得以迅速缓解。亦适用于缓解慢性荨麻疹、瘙痒性皮肤病及其他过敏性皮肤病的症状及体征。','西药','盒','内服药','片剂','20231201','某生物科技公司','2023/12/01','36个月','2026/12/01','国家药品监督管理局','50','40','65')
,('M0013','硝苯地平缓释片','xiaobendipinghuanshipian','20mg*24片','硝苯地平缓释片：与硝苯地平相同，但缓释剂型能提供更稳定的血药浓度，适用于需要长期控制血压的患者。','西药','盒','内服药','片剂','20240108','某制药股份有限公司','2024/01/08','24个月','2026/01/08','国家药品监督管理局','80','64','100')
,('M0014','硝酸甘油片','xiansuanganyoupian','0.5mg*100片','硝酸甘油片：主要用于缓解心绞痛，预防和治疗充血性心力衰竭。','西药','瓶','内服药','片剂','20240810','某生物制药公司','2024/08/10','24个月','2026/08/10','国家药品监督管理局','60','48','75')
,('M0015','华法林钠片','huafalinnapian','2.5mg*30片','华法林钠片：主要用于防治血栓栓塞性疾病，防止血栓形成与发展，如治疗深静脉血栓、肺栓塞、心脏瓣膜置换术后等。','西药','盒','内服药','片剂','20240718','某制药企业','2024/07/18','24个月','2026/07/18','国家药品监督管理局','85','68','105')
,('M0016','辛伐他汀片','xinfatatingpian','20mg*14片','辛伐他汀片：主要用于治疗高胆固醇血症和混合型高脂血症；冠心病和脑中风的防治。','西药','盒','内服药','片剂','20240606','某医药公司','2024/06/06','36个月','2027/06/06','国家药品监督管理局','45','36','55')
,('M0017','氨苯蝶啶片','anbendiedingpian','50mg*24片','氨苯蝶啶片：为保钾利尿药，主要用于治疗水肿性疾病和原发性醛固酮增多症','西药','盒','内服药','片剂','20240512','某制药厂','2024/05/12','24个月','2026/05/12','国家药品监督管理局','75','56','85')
,('M0018','氢氯噻嗪片','qinglvsaiqingpian','25mg*100片','氢氯噻嗪片：主要用于治疗水肿性疾病，可排泄体内过多的钠和水，减少细胞外液容量，消除水肿。常见的包括充血性心力衰竭、肝硬化腹水、肾病综合症、急慢性肾炎水肿、慢性肾功能衰竭早期、肾上腺皮质激素和雌激素治疗所致的钠、水潴留。','西药','瓶','内服药','片剂','20240420','某制药有限公司','2024/04/20','36个月','2027/04/20','国家药品监督管理局','90','72','110')
,('M0019','甲磺酸倍他司汀','jiahuangsuanpeitasiding','6mg*12片','甲磺酸倍他司汀：主要用于治疗梅尼埃病、梅尼埃综合征、眩晕症等疾病伴发的眩晕、头晕感。','西药','盒','内服药','片剂','20240308','某生物科技公司','2024/03/08','24个月','2026/03/08','国家药品监督管理局','55','44','68')
,('M0020','盐酸二甲双胍片','yansuanerjiashuangguapian','500mg*30片','盐酸二甲双胍片：主要用于单纯饮食控制及体育锻炼治疗无效的2型糖尿病，特别是肥胖的2型糖尿病。','西药','盒','内服药','片剂','20240215','某制药企业','2024/02/15','36个月','2027/02/15','国家药品监督管理局','40','32','40')
GO
---11--------------------------------------------------------------------------------------------------
--建表-药品库存属性：药品编号，安全库存量，最小库存量，最大一次库存量
IF OBJECT_ID('tb_MedicineAttribute')IS NOT NULL
DROP TABLE tb_MedicineAttribute
CREATE TABLE tb_MedicineAttribute(
	MedicineNo char(10) PRIMARY KEY NOT NULL,
	SaveNo1 int NOT NULL,
	SaveNo2 int NOT NULL,
	MinNo1 int NOT NULL,
	MinNo2 int NOT NULL,
	MaxNo1 int NOT NULL,
	MaxNo2 int NOT NULL
) 
--增加数据-
INSERT tb_MedicineAttribute (MedicineNo ,SaveNo1 ,SaveNo2,MinNo1 ,MinNo2,MaxNo1,MaxNo2 ) 
VALUES
 ('M0001',10000,10000,30000,3000,50000,5000)
GO
---12--------------------------------------------------------------------------------------------------
--建表-药品入库单：库存单号，药品编号，药品数量，进货日期，供货单位，批准文号，有无合格证，外观是否合格，操作时间，操作人员工号
IF OBJECT_ID('tb_MedicineInventory')IS NOT NULL
DROP TABLE tb_MedicineInventory
CREATE TABLE tb_MedicineInventory(
	No char(20) PRIMARY KEY NOT NULL,
	MedicineNo char(10) NOT NULL,
	Amount int NOT NULL,
	PurchaseDate Date NOT NULL,
	Supplier varchar(20) NOT NULL,
	ApprovalNumber varchar(50) NOT NULL,
	isHasQualified varchar(5) NULL,
	isQualified varchar(5) NULL,
	OperateTime Date NOT NULL,
	OperatorNo char(10) NOT NULL,
	UpdateTime DATETIME 
) 
--增加数据-
INSERT tb_MedicineInventory (No ,MedicineNo ,Amount ,PurchaseDate ,Supplier ,ApprovalNumber ,isHasQualified ,isQualified,OperateTime,OperatorNo ) 
VALUES 
('A001','M0001',500,'2024/01/01','某生物制药企业','国药准字J98765432','是','是','2024/01/01','3220707051')
GO
---13--------------------------------------------------------------------------------------------------
--建表-药品请领单：请领单号，药品编号，请领人工号，请领数量，请领时间，操作人员工号，审定数量
IF OBJECT_ID('tb_MedicineRequest')IS NOT NULL
DROP TABLE tb_MedicineRequest
CREATE TABLE tb_MedicineRequest(
	No char(20) PRIMARY KEY NOT NULL,
	EnterNo char(20),
	MedicineNo char(10) NOT NULL,
	TakeNo char(10) NOT NULL,
	Amount int Not NULL,
	Date date NOT NULL,
	OperatorNo char(10) NOT NULL,
	ReallyAmount int  NULL
) 
--增加数据-
INSERT tb_MedicineRequest (No,MedicineNo ,TakeNo ,Amount ,Date ,OperatorNo ,ReallyAmount  ) 
VALUES 
('R001','M0001','001',20,'2024/01/01','3220707051',20)
GO
---14--------------------------------------------------------------------------------------------------
--建表-药品入房单：入房单编号，请领单编号，药品编号，操作人员编号，入房时间，药品数量
IF OBJECT_ID('tb_MedicineEnterHall')IS NOT NULL
DROP TABLE tb_MedicineEnterHall
CREATE TABLE tb_MedicineEnterHall(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	RequestNo char(20) NOT NULL,
	MedicineNo char(20) NOT NULL,
	OperatorNo char(20) NOT NULL,
	Date Date NOT NULL,
	Amount int NULL
)
GO

---15--------------------------------------------------------------------------------------------------
--建表-药品退房单：退房单编号，病区号，退房护士编号，退药编号，退药数量，退房时间
IF OBJECT_ID('tb_MedicineBackHall')IS NOT NULL
DROP TABLE tb_MedicineBackHall
CREATE TABLE tb_MedicineBackHall(
	No char(20) PRIMARY KEY NOT NULL,
	HallNo char(10) NOT NULL,
	NurseNo char(10) NOT NULL,
	MedicineNo char(10) NOT NULL,
	Amount int Not NULL,
	Date Date NOT NULL
)
GO
---16--------------------------------------------------------------------------------------------------
--建表-药品盘点单：药品盘点单编号，盘点类型，盘点方式，盘点日期，操作人员工号
IF OBJECT_ID('tb_MedicineCheck')IS NOT NULL
DROP TABLE tb_MedicineCheck
CREATE TABLE tb_MedicineCheck(
	No char(20) PRIMARY KEY NOT NULL,
	CheckType char(20) NOT NULL,
	CheckForm char(20) NOT NULL,
	Date DateTIME NOT NULL,
	OperatorNo char(20) NOT NULL
) 
GO
INSERT tb_MedicineCheck(No,CheckType,CheckForm ,Date,OperatorNo)
VALUES('','','','','');
INSERT tb_MedicineCheck(No,CheckType,CheckForm ,Date,OperatorNo)
                VALUES('C202405210001','日盘','全部盘平','2024/5/21 0:56:23','3220707051');
SELECT * FROM tb_MedicineCheck
--建表-药品盘点细则单：盘点单号，入库单号/入房单号，盘点数量，盘点备注
IF OBJECT_ID('tb_MedicineCheckPro')IS NOT NULL
DROP TABLE tb_MedicineCheckPro
CREATE TABLE tb_MedicineCheckPro(
	CheckNo char(20)  NOT NULL,
	StoreNo char(20) NOT NULL,
	Amount int ,
	Remark char(100) 
) 
GO
INSERT tb_MedicineCheckPro(CheckNo ,StoreNo,Amount,Remark )
VALUES('','','','');
SELECT * FROM tb_MedicineCheckPro
---17--------------------------------------------------------------------------------------------------
--建表-药品出房单：出房单编号，药品编号，领药数量，操作时间，领药护士工号
IF OBJECT_ID('tb_MedicineLeaveHall')IS NOT NULL
DROP TABLE tb_MedicineLeaveHall
CREATE TABLE tb_MedicineLeaveHall(
	No char(10) PRIMARY KEY NOT NULL,
	MedicineNo char(20) NOT NULL,
	Amount int Not NULL,
	Date Date NOT NULL,
	NurseNo char(10) NOT NULL
)
GO
---18--------------------------------------------------------------------------------------------------
--建表-药品退库单：退库单号，报损单编号，退库数量，退库原因，操作人员名单，退库时间
IF OBJECT_ID('tb_MedicineBackStore')IS NOT NULL
DROP TABLE tb_MedicineBackStore
CREATE TABLE tb_MedicineBackStore(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	RestoreNo char(20) NOT NULL,
	Amount int Not NULL,
	OperatorNo char(20) NOT NULL,
	Date Date NOT NULL
) 

---19--------------------------------------------------------------------------------------------------
--建表-药品报损单：报损单号，入库编号，报损数量，操作人员名单，报损时间，报损原因
IF OBJECT_ID('tb_MedicineBad')IS NOT NULL
DROP TABLE tb_MedicineBad
CREATE TABLE tb_MedicineBad(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	StoreNo char(20) NOT NULL,
	Amount int Not NULL,
	OperatorNo char(10) NOT NULL,
	Date Date NOT NULL,
	Result varchar(50)
)
GO

---20-------------------------------------------------------------------------------------
--建表-药品请领单审批
IF OBJECT_ID('tb_IsMedicineRequest')IS NOT NULL
DROP TABLE tb_IsMedicineRequest
CREATE TABLE tb_IsMedicineRequest(
	ReQuestNo char(20) PRIMARY KEY NOT NULL,
	Amount int  NOT NULL,
	Date date NOT NULL
) 
--增加数据-
INSERT tb_IsMedicineRequest (Amount ,ReQuestNo ,Date ) 
VALUES 
('','',GETDATE())
-----是否数据--
IF OBJECT_ID('tb_YesNo')IS NOT NULL
DROP TABLE tb_YesNo
CREATE TABLE tb_YesNo(
	No char(10) PRIMARY KEY NOT NULL,
	Text char(10) NOT NULL
) 
--增加数据-
INSERT tb_YesNo (No ,Text ) 
VALUES 
('1','是'),('2','否')
Select * from tb_YesNo
-----供货单位--
IF OBJECT_ID('tb_Supplier')IS NOT NULL
DROP TABLE tb_Supplier
CREATE TABLE tb_Supplier(
	No char(10) PRIMARY KEY NOT NULL,
	Text char(20) NOT NULL
) 
--增加数据-
INSERT tb_Supplier (No ,Text ) 
VALUES 
('1','中国国药有限公司'),('2','中国西药有限公司')
Select * from tb_Supplier
-----病房--
IF OBJECT_ID('tb_SickRoom')IS NOT NULL
DROP TABLE tb_SickRoom
CREATE TABLE tb_SickRoom(
	No int PRIMARY KEY NOT NULL,
	WardNo int NOT NULL,
	Name char(20) NOT NULL
) 
--增加数据-
INSERT tb_SickRoom (No ,WardNo,Name ) 
VALUES 
(1,1,'病房101'),
(2,1,'病房102'),
(3,2,'病房201'),
(4,2,'病房202'),
(5,3,'病房301'),
(6,3,'病房302'),
(7,4,'病房401'),
(8,4,'病房401'),
(9,5,'病房501'),
(10,5,'病房502')
-----病人--
IF OBJECT_ID('tb_SickMan')IS NOT NULL
DROP TABLE tb_SickMan
CREATE TABLE tb_SickMan(
	No int PRIMARY KEY NOT NULL,
	RoomNo int NOT NULL,
	Name char(20) NOT NULL
) 
--增加数据-
INSERT tb_SickMan(No ,RoomNo,Name ) 
VALUES 
(1,1,'病人1'),
(2,2,'病人2'),
(3,3,'病人3'),
(4,4,'病人4'),
(5,5,'病人5'),
(6,6,'病人6'),
(7,7,'病人7'),
(8,8,'病人8'),
(9,9,'病人9'),
(10,10,'病人10')
-----------------------------------------------------------------------------------------------------
--建表-药品出房病人药品明细单：出房单编号，药品名称，病区，病房，病人，操作人员编号，出房房时间，药品数量，护士
IF OBJECT_ID('tb_MedicineOutHall')IS NOT NULL
DROP TABLE tb_MedicineOutHall
CREATE TABLE tb_MedicineOutHall(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MedicineName char(20) NOT NULL,
	WardName char(20) NOT NULL,
	RoomName char(20) NOT NULL,
	ManName char(20) NOT NULL,
	OperateNo char(20) NOT NULL,
	Date Date NOT NULL,
	Amount int NULL,
	Nurse varchar(20) NOT Null
)
-----过期原因-------------------------------------------------------------
IF OBJECT_ID('tb_OutDateResult')IS NOT NULL
DROP TABLE tb_OutDateResult
CREATE TABLE tb_OutDateResult(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Text char(20) NOT NULL
) 
--增加数据-
INSERT tb_OutDateResult (Text ) 
VALUES 
('药品过期'),('药品破损'),('药品变质'),('药品不合格'),('其他原因')
-----药品类型-------------------------------------------------------------
IF OBJECT_ID('tb_MedicineType')IS NOT NULL
DROP TABLE tb_MedicineType
CREATE TABLE tb_MedicineType(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Text char(20) NOT NULL
) 
--增加数据-
INSERT tb_MedicineType (Text ) 
VALUES 
('全部'),('西药'),('中成药')
-----盘点类型-------------------------------------------------------------
IF OBJECT_ID('tb_InventoryType')IS NOT NULL
DROP TABLE tb_InventoryType
CREATE TABLE tb_InventoryType(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Text char(20) NOT NULL
) 
--增加数据-
INSERT tb_InventoryType (Text ) 
VALUES 
('日盘'),('月盘'),('季盘')
-----盘点方式-------------------------------------------------------------
IF OBJECT_ID('tb_InventoryForm')IS NOT NULL
DROP TABLE tb_InventoryForm
CREATE TABLE tb_InventoryForm(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Text char(20) NOT NULL
) 
--增加数据-
INSERT tb_InventoryForm (Text ) 
VALUES 
('全部盘平'),('全部盘零'),('部分盘点')
-----药品性质-------------------------------------------------------------
IF OBJECT_ID('tb_MedicineProperty')IS NOT NULL
DROP TABLE tb_MedicineProperty
CREATE TABLE tb_MedicineProperty(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Text char(20) NOT NULL
) 
--增加数据-
INSERT tb_MedicineProperty (Text ) 
VALUES 
('全部'),('内服药'),('注射药')
-----药品剂型-------------------------------------------------------------
IF OBJECT_ID('tb_MedicineForm')IS NOT NULL
DROP TABLE tb_MedicineForm
CREATE TABLE tb_MedicineForm(
	No int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Text char(20) NOT NULL
) 
--增加数据-
INSERT tb_MedicineForm (Text ) 
VALUES 
('全部'),('片剂'),('胶囊'),('丸剂'),('颗粒剂'),('注射剂')
--建表-个人密保表（学号，教师工号，姓名，密保1，答案1，密保2，答案2）
IF OBJECT_ID('tb_ChangeInformation')IS NOT NULL
DROP TABLE tb_ChangeInformation
CREATE TABLE tb_ChangeInformation(
	NO char(10) PRIMARY KEY NOT NULL,
	PasswordQuestional1 varchar(100) NULL,
	Answer1 varchar(100) NULL,
	PasswordQuestional2 varchar(100) NULL,
	Answer2 varchar(100) NULL
) 
--增加数据-个人密保表
INSERT tb_ChangeInformation
(NO,PasswordQuestional1,Answer1 ,PasswordQuestional2,Answer2)
VALUES
('3220707051','籍贯','江西赣州','年龄','20')

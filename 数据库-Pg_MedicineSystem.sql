CREATE USER "Administrator" SUPERUSER PASSWORD '';


SELECT pg_terminate_backend(A.pid) 
	FROM pg_stat_activity AS A 
	WHERE A.datname='MedicineSystem' AND A.pid<>pg_backend_pid();

DROP DATABASE IF EXISTS "MedicineSystem";

DROP TABLESPACE IF EXISTS "ts_MedicineSystem";

CREATE TABLESPACE "ts_MedicineSystem" LOCATION 'D:\DATA\MedicineSystem';
CREATE DATABASE "MedicineSystem" TABLESPACE "ts_MedicineSystem";

DROP TABLE IF EXISTS tb_operator CASCADE;

using database "MedicineSystem";
--操作人员表；
CREATE TABLE tb_operator
	(no
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,user_No
		varchar(20)
		NOT NULL
	,name
		varchar(10)
	 	NOT NULL
	,sex
		varchar(10)
		NOT NULL
	,birthday
		DATE
		NOT NULL
	,age
		int
		NULL
	,phone
		varchar(20)
		NULL
	,address
		varchar(100)
		NULL
	,photo
		TEXT
		NULL);

INSERT INTO tb_operator
	(NO ,User_No,Name,Sex ,birthday,Age ,Phone ,Address)
	VALUES
	('3220707051','3220707051','曾海红','女','2003-2-15','21','15605089826','江西赣州');
--根据用户号查询操作人员
SELECT 
		*
	FROM
		tb_operator

SELECT table_name   
FROM information_schema.tables   
WHERE table_schema = 'public' AND table_name = 'tb_operator';
SELECT datname FROM pg_database;



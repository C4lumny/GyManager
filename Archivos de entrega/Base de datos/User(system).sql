SET SERVEROUTPUT ON;
GRANT ALL PRIVILEGES TO SYSTEM;

CREATE ROLE ADMINISTRADOR_;
GRANT CREATE SESSION, CREATE USER, create trigger, CREATE PROCEDURE, CREATE SEQUENCE, SELECT ANY TABLE, CREATE PUBLIC SYNONYM, CREATE VIEW, 
CREATE TABLE, INSERT ANY TABLE, DROP ANY TABLE, DELETE ANY TABLE, UPDATE ANY TABLE, CREATE ANY JOB, SELECT_CATALOG_ROLE, SELECT ANY DICTIONARY TO ADMINISTRADOR_;

CREATE TABLESPACE gymanager DATAFILE '' SIZE 100M; 

CREATE USER Aisaac IDENTIFIED BY 1234 DEFAULT TABLESPACE gymanager TEMPORARY TABLESPACE TEMP QUOTA UNLIMITED ON gymanager;

GRANT ADMINISTRADOR_ TO Aisaac;
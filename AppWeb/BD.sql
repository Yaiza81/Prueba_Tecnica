create database empresa1; 
use empresa1;

CREATE TABLE departamento
(codigo_departamento INT auto_increment primary KEY,
nombre_depto VARCHAR(75));

CREATE TABLE puesto
(codigo_puesto INT auto_increment primary KEY,
nombre_puesto VARCHAR(75));

CREATE TABLE empleado
(
id_empleado int auto_increment primary key,
dpi INT,
nombre VARCHAR(100),
apellidos VARCHAR(125),
fecha_inicio datetime not null default current_timestamp,
fecha_baja  date null,
fecha_ult_aumento date null,
sueldo int,
cod_depto INT ,
cod_puesto INT,
FOREIGN KEY (cod_depto)
REFERENCES departamento(codigo_departamento),
FOREIGN KEY (cod_puesto)
REFERENCES puesto(codigo_puesto)
);
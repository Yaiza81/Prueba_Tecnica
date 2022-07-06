use empresa; 

# 1.	Obtener todos los apellidos de los empleados. 
			SELECT apellidos FROM empleado;
            
# 2.	 Obtener los apellidos de los empleados sin repeticiones. 
			SELECT DISTINCT apellidos from empleado;
            
# 3.	Obtener todos los datos de los empleados que se apellidan “Pérez” 
			SELECT * FROM empleado
            WHERE SUBSTRING_INDEX(apellidos,' ',1) = 'Pérez' 
            OR SUBSTRING_INDEX(apellidos,' ',-1) = 'Pérez';
            
# 4.	Obtener todos los datos de los empleados que se apellidan “Pérez” o “López” 
			SELECT * FROM empleado
            WHERE (SUBSTRING_INDEX(apellidos,' ',1) = 'Pérez' 
            OR SUBSTRING_INDEX(apellidos,' ',-1) = 'Pérez') 
            OR (SUBSTRING_INDEX(apellidos,' ',1) = 'López' 
            OR SUBSTRING_INDEX(apellidos,' ',-1) = 'López') ;
            
# 5.	Obtener todos los datos de los empleados que trabajan para el departamento “Contabilidad” 
			SELECT dpi,nombre, apellidos, cod_depto FROM empleado e, departamento d
            WHERE e.cod_depto = d.codigo_departamento
            AND d.nombre_depto = 'Contabilidad';
            
# 6.	Obtener todos los datos de los empleados que trabajan para el departamento “Contabilidad” y “Gerencial General” 
			SELECT dpi,nombre, apellidos, cod_depto FROM empleado e, departamento d
            WHERE e.cod_depto = d.codigo_departamento
            AND (d.nombre_depto = 'Contabilidad' OR d.nombre_depto = 'Gerencial General');
            
# 7.	Obtener todos los datos de los empleados cuyo apellido comienza por la letra “P” 
				SELECT * FROM empleado
				WHERE SUBSTRING_INDEX(apellidos,' ',1) LIKE 'P%' 
				OR SUBSTRING_INDEX(apellidos,' ',-1) LIKE 'P%';

# 8.	Obtener el presupuesto total de todos los departamentos. 
			SELECT SUM(presupuesto) as Presupuesto_Total FROM departamento;
            
# 9.	Obtener el número de empleados por cada departamento. 
			SELECT cod_depto, d.nombre_depto as Departamento, COUNT(*) as 'Cantidad Empleados'
			FROM empleado e, departamento d
            WHERE e.cod_depto = d.codigo_departamento
			GROUP BY cod_depto; 
            
# 10.	Obtener un listado completo de empleados, incluyendo por cada empleado los datos del empleado y de su departamento. 
			SELECT * FROM empleado e, departamento d
			WHERE e.cod_depto = d.codigo_departamento;

# 11.	Obtener un listado completo de empleados, mostrando su nombre y apellido, junto con el nombre y 
#        presupuesto del departamento. Todo ordenado descendentemente por el apellido. 
			SELECT e.nombre, e.apellidos, d.nombre_depto, d.presupuesto
            FROM empleado e, departamento d
            WHERE e.cod_depto = d.codigo_departamento
            order by e.apellidos desc; 

# 12.	Obtener los nombres y apellidos de los empleados que trabajen en departamentos cuyo presupuesto
#		sea mayor a 60,000. 
			SELECT e.nombre, e.apellidos  FROM empleado e, departamento d
            WHERE e.cod_depto = d.codigo_departamento
            AND d.presupuesto > 60000;

# 13.	Obtener los datos de los departamentos cuyo presupuesto es superior al presupuesto 
#       medio de todos los departamentos. 
			SELECT * FROM departamento
			WHERE presupuesto > (
			SELECT AVG(presupuesto) FROM departamento );

# 14.	Obtener los nombres de los departamentos que tienen más de 2 empleados. 
				SELECT nombre_depto FROM departamento 
				WHERE codigo_departamento IN (
							 SELECT cod_depto
							 FROM empleado
							 GROUP BY cod_depto
							 HAVING COUNT(*) > 2
						);
                        
# 15.	Agregar un nuevo departamento “Control de Calidad”, con presupuesto de 40,000 y código 11. Y agregar un empleado vinculado a este departamento de nombre Esther Vásquez y con DNI: 28948238
			INSERT INTO departamento VALUES ( 11 , 'Control de Calidad' , 40000);
			INSERT INTO empleado VALUES ('28948238', 'Esther', 'Vázquez', 11);
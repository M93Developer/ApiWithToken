/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.	
 Inserta o Actualiza datos estáticos
 Pepito tiene clave 1234
--------------------------------------------------------------------------------------
*/
merge [dbo].[ApiUsers] as [target]
using (
    values 
    ('Pepito', '7110eda4d09e062aa5e4a390b0a572ac0d2c0220', null)
) as [source] ([ApUsuName],[ApUsuPass],[ApUsuRol])
on target.[ApUsuName] = [source].[ApUsuName]
when matched then
    update set 
        [ApUsuName] = [source].[ApUsuName],
        [ApUsuPass] = [source].[ApUsuPass],
        [ApUsuRol] = [source].[ApUsuRol]
when not matched then
    insert ([ApUsuName],[ApUsuPass],[ApUsuRol])
    values ([source].[ApUsuName], [source].[ApUsuPass], [source].[ApUsuRol]);
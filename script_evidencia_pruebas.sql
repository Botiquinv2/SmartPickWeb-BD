USE SmartPickWeb;
GO

SET IDENTITY_INSERT PERFILES ON;
INSERT INTO PERFILES (id_perfil, nombre_perfil) VALUES (1, 'Admin'), (2, 'Picker');
SET IDENTITY_INSERT PERFILES OFF;

SET IDENTITY_INSERT UBICACIONES ON;
INSERT INTO UBICACIONES (id_ubicacion, pasillo, estante, nivel) VALUES (1, 'A', '3', '1');
SET IDENTITY_INSERT UBICACIONES OFF;

SET IDENTITY_INSERT CATEGORIAS ON;
INSERT INTO CATEGORIAS (id_categoria, nombre_categoria, descripcion) VALUES (1, 'Herramientas', 'Ferretería general');
SET IDENTITY_INSERT CATEGORIAS OFF;
----------------------------------------------------------------------------
INSERT INTO PRODUCTOS (sku, nombre_producto, id_categoria, id_ubicacion) VALUES ('SKU987', 'Martillo', 1, 1);

SET IDENTITY_INSERT CLIENTES ON;
INSERT INTO CLIENTES (id_cliente, nombre_razon_social, rut, direccion) VALUES (1, 'Constructora SPA', '77.777.777-7', 'Av. Arturo Prat 123');
SET IDENTITY_INSERT CLIENTES OFF;

SET IDENTITY_INSERT USUARIOS ON;
INSERT INTO USUARIOS (id_usuario, nombre, rut, password, id_perfil) VALUES (1, 'Juan Luna', '20.233.222-2', '1234', 1);
SET IDENTITY_INSERT USUARIOS OFF;

SET IDENTITY_INSERT PEDIDOS ON;
INSERT INTO PEDIDOS (id_pedido, fecha_creacion, estado, id_cliente, id_usuario_admin) VALUES (1, GETDATE(), 1, 1, 1);
SET IDENTITY_INSERT PEDIDOS OFF;

SET IDENTITY_INSERT DETALLE_PEDIDO ON;
INSERT INTO DETALLE_PEDIDO (id_detalle, id_pedido, sku, cantidad, estado_recoleccion) VALUES (1, 1, 'SKU987', 10, 1);
SET IDENTITY_INSERT DETALLE_PEDIDO OFF;

SELECT id_detalle, id_pedido, sku, cantidad, estado_recoleccion 
FROM DETALLE_PEDIDO;

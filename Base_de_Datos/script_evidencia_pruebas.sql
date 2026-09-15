-- USE db_ace274_smartpickdb;
-- GO

SET IDENTITY_INSERT PERFILES ON;
INSERT INTO PERFILES (id_perfil, nombre_perfil) VALUES 
(1, 'Administrador'), 
(2, 'Picker');
SET IDENTITY_INSERT PERFILES OFF;

SET IDENTITY_INSERT UBICACIONES ON;
INSERT INTO UBICACIONES (id_ubicacion, pasillo, estante, nivel) VALUES 
(1, 'A', '1', '1'),
(2, 'A', '3', '2'),
(3, 'B', '1', '1'),
(4, 'C', '2', '3');
SET IDENTITY_INSERT UBICACIONES OFF;

SET IDENTITY_INSERT CATEGORIAS ON;
INSERT INTO CATEGORIAS (id_categoria, nombre_categoria, descripcion) VALUES 
(1, 'Herramientas', 'Herramientas manuales y eléctricas'),
(2, 'Electricidad', 'Insumos y cableado'),
(3, 'EPP', 'Equipos de Protección Personal');
SET IDENTITY_INSERT CATEGORIAS OFF;

-- Inserción de catálogo con SKUs reales y variedad de stock
INSERT INTO PRODUCTOS (sku, nombre_producto, stock, id_categoria, id_ubicacion) VALUES 
('SKU-HR987', 'Martillo Carpintero 16oz', 50, 1, 1),
('SKU-HR452', 'Taladro Inalámbrico 20V', 15, 1, 2),
('SKU-EL102', 'Rollo Cable Cobre 2.5mm', 120, 2, 3),
('SKU-EPP05', 'Casco Seguridad Blanco', 80, 3, 4);

SET IDENTITY_INSERT CLIENTES ON;
-- Clientes con RUTs corporativos realistas y direcciones estructuradas
INSERT INTO CLIENTES (id_cliente, nombre_razon_social, rut, direccion) VALUES 
(1, 'Constructora Nueva Era SpA', '76.453.211-K', 'Av. Apoquindo 4500, Las Condes'),
(2, 'Ferretería El Maestro Ltda.', '77.123.456-7', 'San Diego 1020, Santiago');
SET IDENTITY_INSERT CLIENTES OFF;

SET IDENTITY_INSERT USUARIOS ON;
-- Equipo de trabajo con RUTs reales. Se agregan dos pickers para probar concurrencia.
INSERT INTO USUARIOS (id_usuario, nombre, rut, password, id_perfil) VALUES 
(1, 'Juan Luna', '20.233.222-2', 'admin123', 1),
(2, 'Cristóbal Vargas', '20.543.876-9', 'picker1', 2),
(3, 'Daniela Rojas', '19.876.543-K', 'picker2', 2);
SET IDENTITY_INSERT USUARIOS OFF;

SET IDENTITY_INSERT PEDIDOS ON;
-- CORREGIDO: Se incorpora la asignación obligatoria de id_usuario_picker para evitar que dos trabajadores tomen la misma ruta, respondiendo al feedback de la entrega pasada.
INSERT INTO PEDIDOS (id_pedido, fecha_creacion, estado, id_cliente, id_usuario_admin, id_usuario_picker) VALUES 
(1, GETDATE(), 1, 1, 1, 2),
(2, GETDATE(), 1, 2, 1, 3);
SET IDENTITY_INSERT PEDIDOS OFF;

-- CORREGIDO: Se aplica el rediseño bajo la Segunda Forma Normal (2FN) eliminando el ID artificial. La inserción ahora se hace directamente sobre la clave primaria compuesta.
INSERT INTO DETALLE_PEDIDO (id_pedido, sku, cantidad, estado_recoleccion) VALUES 
(1, 'SKU-HR987', 5, 0),
(1, 'SKU-HR452', 2, 0),
(1, 'SKU-EL102', 10, 0),
(2, 'SKU-EPP05', 15, 0),
(2, 'SKU-HR987', 3, 0);
------------------------------------------------------------------:D--------------------------------------------------------------------------------------------------------
-- Evidencia para CP08: Verifica el estado de los ítems recolectados
SELECT id_pedido, sku, cantidad, estado_recoleccion 
FROM DETALLE_PEDIDO;

-- Evidencia para CP10: Verifica el estado general de las órdenes
SELECT id_pedido, fecha_creacion, estado, id_usuario_picker 
FROM PEDIDOS;
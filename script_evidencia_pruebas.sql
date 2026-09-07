-- 1. Creación de la Base de Datos
CREATE DATABASE SmartPickWeb;
GO

USE SmartPickWeb;
GO

-- 2. Creación de Tablas de Catálogo y Maestros (Sin dependencias)
CREATE TABLE PERFILES (
    id_perfil INT IDENTITY(1,1) PRIMARY KEY,
    nombre_perfil VARCHAR(50) NOT NULL
);

CREATE TABLE CATEGORIAS (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre_categoria VARCHAR(50) NOT NULL,
    descripcion VARCHAR(150) NULL
);

CREATE TABLE UBICACIONES (
    id_ubicacion INT IDENTITY(1,1) PRIMARY KEY,
    pasillo VARCHAR(10) NOT NULL,
    estante VARCHAR(10) NOT NULL,
    nivel VARCHAR(10) NOT NULL
);

CREATE TABLE CLIENTES (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre_razon_social VARCHAR(100) NOT NULL,
    rut VARCHAR(12) UNIQUE NOT NULL,
    direccion VARCHAR(200) NOT NULL
);

-- 3. Creación de Tablas con Dependencias (Con Claves Foráneas)
CREATE TABLE USUARIOS (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    rut VARCHAR(12) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    id_perfil INT NOT NULL,
    FOREIGN KEY (id_perfil) REFERENCES PERFILES(id_perfil)
);

CREATE TABLE PRODUCTOS (
    sku VARCHAR(20) PRIMARY KEY,
    nombre_producto VARCHAR(100) NOT NULL,
    id_categoria INT NOT NULL,
    id_ubicacion INT NOT NULL,
    FOREIGN KEY (id_categoria) REFERENCES CATEGORIAS(id_categoria),
    FOREIGN KEY (id_ubicacion) REFERENCES UBICACIONES(id_ubicacion)
);

CREATE TABLE PEDIDOS (
    id_pedido INT IDENTITY(1,1) PRIMARY KEY,
    fecha_creacion DATETIME DEFAULT GETDATE(),
    estado INT NOT NULL,
    id_cliente INT NOT NULL,
    id_usuario_admin INT NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES CLIENTES(id_cliente),
    FOREIGN KEY (id_usuario_admin) REFERENCES USUARIOS(id_usuario)
);

CREATE TABLE DETALLE_PEDIDO (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_pedido INT NOT NULL,
    sku VARCHAR(20) NOT NULL,
    cantidad INT NOT NULL,
    estado_recoleccion INT DEFAULT 0,
    FOREIGN KEY (id_pedido) REFERENCES PEDIDOS(id_pedido),
    FOREIGN KEY (sku) REFERENCES PRODUCTOS(sku)
);
GO
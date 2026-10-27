CREATE DATABASE IF NOT EXISTS tienda CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE tienda;

DROP TABLE IF EXISTS clientes;

CREATE TABLE clientes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    telefono VARCHAR(20) NOT NULL,
    ciudad VARCHAR(50) NOT NULL
);

INSERT INTO clientes (nombre, telefono, ciudad) VALUES
    ('Lucía Benítez', '0981 123 456', 'Asunción'),
    ('Mateo Ayala', '0982 234 567', 'San Lorenzo'),
    ('Rosa Giménez', '0983 345 678', 'Luque'),
    ('Carlos Duarte', '0984 456 789', 'Lambaré'),
    ('Elena Duarte', '0985 567 890', 'Fernando de la Mora');
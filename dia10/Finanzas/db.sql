CREATE DATABASE IF NOT EXISTS finanzas CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE finanzas;

DROP TABLE IF EXISTS movimientos;

CREATE TABLE movimientos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    monto INT NOT NULL,
    tipo VARCHAR(10) NOT NULL,
    descripcion VARCHAR(200) NOT NULL
);

INSERT INTO movimientos (monto, tipo, descripcion) VALUES
    (150000, 'Ingreso', 'Venta del día'),
    (45000, 'Egreso', 'Compra de mercadería'),
    (80000, 'Ingreso', 'Venta de recargas'),
    (12000, 'Egreso', 'Pago de transporte'),
    (30000, 'Egreso', 'Servicio de luz');
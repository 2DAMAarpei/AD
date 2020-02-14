create database tienda;
use tienda;
create table categorias(
	idCat int NOT NULL AUTO_INCREMENT,
	nombre VARCHAR(20) NOT NULL,
	PRIMARY KEY(idCat)
);

create table productos(
	idProd int NOT NULL AUTO_INCREMENT,
	idCat int NOT NULL,
	nombre VARCHAR(20) NOT NULL,
	precio float NOT NULL, 
	PRIMARY KEY(idProd),
	FOREIGN KEY (idCat) REFERENCES categorias(idCat) ON DELETE CASCADE
);

create table clientes(
	idCli int NOT NULL AUTO_INCREMENT,
	nombre VARCHAR(20) NOT NULL,
	PRIMARY KEY(idCli)
);

create table pedidos(
	idPed int NOT NULL AUTO_INCREMENT,
	idCli int NOT NULL,
	fecha date NOT NULL, 
	PRIMARY KEY(idPed),
	FOREIGN KEY (idCli) REFERENCES clientes(idCli) ON DELETE CASCADE
);

create table lineasPedido(
	idLinea int NOT NULL AUTO_INCREMENT,
	idPed int NOT NULL,
	idProd int NOT NULL,
	PRIMARY KEY(idLinea),
	FOREIGN KEY (idPed) REFERENCES pedidos(idPed) ON DELETE CASCADE,
	FOREIGN KEY (idProd) REFERENCES productos(idProd) ON DELETE CASCADE
);

### VALUES ###
insert into clientes (nombre) values("User_Test");
insert into categorias (nombre) values ("Testing");
insert into productos (idCat, nombre,precio) values(1,"TestProd",3.5);
insert into pedidos (idCli,fecha) values(1,'1996-10-08');
insert into lineasPedido (idPed,idProd) values (1,1);




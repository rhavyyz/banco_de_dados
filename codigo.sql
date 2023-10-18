CREATE TABLE Colaboration_Permission
(
  	id int,
  	name char(20),
	PRIMARY KEY(id)
);

CREATE TABLE User_Permission
(
  	id int,
  	name char(20),
	PRIMARY KEY(id)
);

CREATE TABLE User
(
  	email char(30),
  	name char(80),
  	pass_hash varchar(30),
  	id_permission int,
	PRIMARY KEY(email),
  	FOREIGN key(id_permission) REFERENCES User_Permission(id)
);

CREATE TABLE Post
(
  	id int,
  	title varchar(20),
  	subtitle varchar(40),
  	content varchar(200),
  	date varchar(10),
  	approved char(10),
  	id_user int,
  	PRIMARY KEY(id),
  	FOREIGN KEY(id_user) REFERENCES User(id)
);

CREATE table Colaboration
(
	id_user int,
  	id_post int,
  	id_colaboration_permission int,
  	PRIMARY key(id_user, id_post),
  	FOREIGN key(id_user) REFERENCES User(id),
  	FOREIGN key(id_post) REFERENCES Post(id),
  	FOREIGN key(id_colaboration_permission) REFERENCES Colaboration_Permission(id)
);

CREATE TABLE Likes
(
	id_user int,
  	id_post int,
  	PRIMARY key(id_user, id_post),
  	FOREIGN KEY(id_user) REFERENCES User(id),
  	FOREIGN KEY(id_post) REFERENCES Post(id)
);

CREATE table Comment
(
  	id int,
	content varchar(200),
  	publish_date varchar(10),
  	id_user int,
  	id_post int,
  	PRIMARY KEY(id),
  	FOREIGN key(id_user) REFERENCES User(id),
  	FOREIGN key(id_post) REFERENCES Post(id)
);

CREATE TABLE Category
(
	id int,
  	id_parent int,
  	name char(80),
  	PRIMARY key(id),
  	FOREIGN key(id_parent) REFERENCES Category(id)
);

CREATE table Post_Category
(
	id_category int,
  	id_post int,
  	PRIMARY key(id_category, id_post),
  	FOREIGN KEY(id_category) REFERENCES Category(id),
  	FOREIGN key(id_post) REFERENCES Post(id)
);
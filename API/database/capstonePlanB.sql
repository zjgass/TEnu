USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

BEGIN TRANSACTION;

--create tables
CREATE TABLE users
(
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO

CREATE TABLE ingredient
(
	ingredient_id int IDENTITY(1,1) NOT NULL,
	ingredient_name varchar(25) NOT NULL,

	constraint pk_ingredient primary key(ingredient_id)
);

--Recipe Table
CREATE TABLE recipe
(
	recipe_id int IDENTITY(1,1) NOT NULL,
	recipe_name varchar(50) NOT NULL,
	is_public bit NOT NULL,
	serves int NOT NULL,
	prep_time varchar(20),
	cook_time varchar(20),
	total_time varchar(20),
	utensils nvarchar(4000),
	instructions nvarchar(4000) NOT NULL,
	img_url varchar(200)

	constraint pk_recipe primary key(recipe_id)
);

--Recipe Users Join Table
CREATE TABLE recipe_users
(
	recipe_id int NOT NULL,
	user_id int NOT NULL,

	constraint pk_recipe_users 
		primary key(recipe_id, user_id),
	constraint fk_recipe_users_recipe
		foreign key(recipe_id)
		references recipe(recipe_id),
	constraint fk_recipe_users_users
		foreign key(user_id)
		references users(user_id)
);

CREATE TABLE ingredient_recipe
(
	ingredient_id int NOT NULL,
	recipe_id int NOT NULL,
	quantity float NOT NULL,
	unit varchar(25) NOT NULL,

	constraint pk_ingredient_recipe
		primary key(ingredient_id, recipe_id),
	constraint fk_ingredient_recipe_ingredient
		foreign key(ingredient_id)
		references ingredient(ingredient_id),
	constraint fk_ingredient_recipe_recipe
		foreign key(recipe_id)
		references recipe(recipe_id)
);

--Category Table
CREATE TABLE category
(
	category_id int IDENTITY(1,1) NOT NULL,
	category_name varchar(50) NOT NULL

	constraint pk_category primary key(category_id)
);

--Recipe Category Join Table
CREATE TABLE category_recipe
(
	category_id int NOT NULL,
	recipe_id int NOT NULL,

	constraint pk_category_recipe
		primary key(category_id, recipe_id),
	constraint fk_category_recipe_category
		foreign key(category_id)
		references category(category_id),
	constraint fk_category_recipe_recipe
		foreign key(recipe_id)
		references recipe(recipe_id)
);

--Meal Table
CREATE TABLE meal
(
	meal_id int IDENTITY(1,1) NOT NULL,
	meal_name varchar(50),

	constraint pk_meal primary key(meal_id)
);

--Meal Recipe Join Table
CREATE TABLE meal_recipe
(
	meal_id	int	NOT NULL,
	recipe_id int NOT NULL,

	constraint pk_meal_recipe
		primary key(meal_id, recipe_id),
	constraint fk_meal_recipe_meal
		foreign key(meal_id)
		references meal(meal_id),
	constraint fk_meal_recipe_recipe
		foreign key(recipe_id)
		references recipe(recipe_id)
);

--Plan Table
CREATE TABLE meal_plan
(
	meal_plan_id int IDENTITY(1,1) NOT NULL,
	meal_plan_name varchar(50),
	user_id int NOT NULL,

	constraint pk_plan primary key(meal_plan_id),
	constraint fk_plan_user
		foreign key(user_id)
		references users(user_id)
);

--Meal Plan Join Table
CREATE TABLE meal_meal_plan
(
	meal_id int NOT NULL,
	meal_plan_id int NOT NULL,

	constraint pk_meal_meal_plan
		primary key(meal_id, meal_plan_id),
	constraint fk_meal_meal_plan_meal
		foreign key(meal_id)
		references meal(meal_id),
	constraint fk_meal_meal_plan_meal_plan
		foreign key(meal_plan_id)
		references meal_plan(meal_plan_id)
);

commit transaction;


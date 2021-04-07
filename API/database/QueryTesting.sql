USE final_capstone
GO

--Search Recipes for an ingredient
select recipe_name
from recipe
where JSON_Query(ingredients, '$') like '%banana%'

--Select a recipe
select recipe_name, is_public, serves, prep_time, cook_time, total_time,
	ingredients, utensils, instructions, img_url
from recipe
where recipe_id = 1;

--Select all recipes for a given user
select recipe_name, is_public, serves, prep_time, cook_time, total_time,
	ingredients, utensils, instructions, img_url
from recipe
join recipe_users on recipe_users.recipe_id = recipe.recipe_id
where user_id = 1;

--Create a new recipe
--insert into recipe (recipe_name, is_public, serves, prep_time, cook_time, total_time,
--	ingredients, utensils, instructions, img_url)
--values(@recipe_name, @is_public, @serves, @prep_time, @cook_time, @total_time,
--	@ingredients, @utensils, @instructions, @img_url)

--Update recipe
--update recipe
--set
--	recipe_name = @recipe_name,
--	is_public = @is_public,
--	serves = @serves,
--	prep_time = @prep_time,
--	cook_time = @cook_time,
--	total_time = @total_time,
--	ingredients = @ingredients,
--	utensils = @utensils,
--	instructions = @instructions,
--	img_url = @img_url
--where recipe_id = @recipe_id

--Delete recipe
begin transaction;

select * from category_recipe;
select * from meal_recipe;
select * from recipe_users;
select * from recipe;

delete from category_recipe
where recipe_id = 1;
delete from meal_recipe
where recipe_id = 1;
delete from recipe_users
where recipe_id = 1;
delete from recipe
where recipe_id = 1;

select * from category_recipe;
select * from meal_recipe;
select * from recipe_users;
select * from recipe;

rollback transaction;

--Select all public recipes
select recipe_name, is_public, serves, prep_time, cook_time, total_time,
	ingredients, utensils, instructions, img_url
from recipe
where is_public = 1;

--Select a meal
select meal_name, recipe_name
from meal
join meal_recipe on meal_recipe.meal_id = meal.meal_id
join recipe on recipe.recipe_id = meal_recipe.recipe_id
where meal.meal_id = 1;

--Select all the recipes on a meal
select recipe_name, is_public, serves, prep_time, cook_time, total_time,
	ingredients, utensils, instructions, img_url
from recipe
join meal_recipe on meal_recipe.recipe_id = recipe.recipe_id
where meal_id = 1;

--Delete a Meal Plan
begin transaction;

select * from meal_mplan;
select * from mplan;

delete from meal_mplan
where mplan_id = 1;
delete from mplan
where mplan_id = 1;

select * from mplan;

rollback transaction;
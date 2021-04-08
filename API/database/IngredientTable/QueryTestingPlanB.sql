USE final_capstone
GO

select recipe_name, is_public, serves, prep_time, cook_time, total_time,
	utensils, instructions, img_url
from recipe
where recipe_id = (select recipe_id from recipe where recipe_name = 'banana bread');

select recipe.recipe_id, recipe_name, description, rating, serves,
	prep_time, cook_time, total_time, utensils, instructions, img_url,
	ingredient.ingredient_name, qty, unit_name
from recipe
join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = recipe.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where ingredient_recipe_unit.recipe_id = 
	(select recipe_id from recipe where recipe_name = 'banana bread');

select *
from meal;

--Check for new ingredients
select * from ingredient;

select ingredient_name
from ingredient
where ingredient_name not in('cherries');

--Get a list of all ingredients
select ingredient_name
from ingredient
join ingredient_recipe_unit on ingredient_recipe_unit.ingredient_id = ingredient.ingredient_id
where recipe_id = 1;

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'maraschino cherries'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'chia seeds'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tbs'), 2),

select recipe.recipe_id, recipe_name, description, is_public, rating, serves, prep_time, cook_time, total_time,
	utensils, instructions, img_url,
	ingredient_name, qty, unit_name
from recipe
join recipe_users on recipe_users.recipe_id = recipe.recipe_id
join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = recipe.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where user_id = 1
order by recipe.recipe_id;

select recipe.recipe_id, recipe_name, description, is_public, rating, serves, prep_time, cook_time, total_time,
	utensils, instructions, img_url,
	ingredient_name, qty, unit_name
from recipe
join recipe_users on recipe_users.recipe_id = recipe.recipe_id
join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = recipe.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where recipe.recipe_id = 1
order by recipe.recipe_id;

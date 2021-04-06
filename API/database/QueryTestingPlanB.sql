USE final_capstone
GO

select recipe_name, is_public, serves, prep_time, cook_time, total_time,
	utensils, instructions, img_url
from recipe
where recipe_id = (select recipe_id from recipe where recipe_name = 'banana bread');

select ingredient_name, quantity, unit
from ingredient
join ingredient_recipe on ingredient_recipe.ingredient_id = ingredient.ingredient_id
where ingredient_recipe.recipe_id = 
	(select recipe_id from recipe where recipe_name = 'banana bread');

select *
from meal;
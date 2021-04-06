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

--Select a meal
select 
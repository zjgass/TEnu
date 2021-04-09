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

--selects recipes for a given user
select recipe.recipe_id, recipe_name, description, rating, serves,
	prep_time, cook_time, total_time, utensils, instructions, img_url, submitted_by,
	ingredient.ingredient_name, qty, unit_name, user_id
from recipe
left join recipe_users on recipe_users.recipe_id = recipe.recipe_id
join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = recipe.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where is_public = 1
order by rating desc, recipe.recipe_id;

select *
from recipe_users;

--Check for new ingredients
select * from ingredient;

select ingredient_name
from ingredient
where ingredient_name not in('cherries');

--Get a list of all ingredients
select ingredient_name
from ingredient

--Insert ingredients into recipes
insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'maraschino cherries'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'chia seeds'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tbs'), 2);

--Selects recipes for a given user
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

--Insert Meal
insert into meal (meal_name, user_id)
values ('veritable feast', 1);
select SCOPE_IDENTITY();
insert into meal_mplan (meal_id, mplan_id, meal_day, meal_time)
values (SCOPE_IDENTITY(), 1, 'monday', 'dinner');
select * from meal_mplan;


--Grocery List
select mplan.mplan_id, mplan_name,
	ingredient.ingredient_id, ingredient_name, qty, unit_name
from mplan
join meal_mplan on meal_mplan.mplan_id = mplan.mplan_id
--join meal on meal.meal_id = meal_mplan.meal_id
join meal_recipe on meal_recipe.meal_id = meal_mplan.meal_id
--join recipe on recipe.recipe_id = meal_recipe.recipe_id
join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = meal_recipe.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where mplan.mplan_id = 1
order by ingredient.ingredient_name;

--Grocery List Sum same ingredient same unit
select mplan.mplan_id, mplan_name,
	ingredient.ingredient_id, ingredient_name, Sum(qty) as total, unit_name
from mplan
join meal_mplan on meal_mplan.mplan_id = mplan.mplan_id
--join meal on meal.meal_id = meal_mplan.meal_id
join meal_recipe on meal_recipe.meal_id = meal_mplan.meal_id
--join recipe on recipe.recipe_id = meal_recipe.recipe_id
join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = meal_recipe.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where mplan.mplan_id = 1
group by mplan.mplan_id, mplan_name, ingredient.ingredient_id, ingredient_name, unit_name
order by ingredient.ingredient_name;


--Search
select recipe.recipe_id, recipe_name, description, is_public, rating, serves,
prep_time, cook_time, total_time,
utensils, instructions, img_url, submitted_by,
ingredient.ingredient_id, ingredient_name, qty, unit_name
from recipe
join recipe_users on recipe_users.recipe_id = recipe.recipe_id
join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = recipe.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where ingredient_name like '%' + 'ban' + '%'
order by recipe.rating, recipe.recipe_name;

--Get meal plan for given meal plan
select mplan.mplan_id, mplan_name, meal.meal_id, meal_name,
	meal_day, meal_time, recipe.recipe_id, recipe_name
from mplan
join meal_mplan on meal_mplan.mplan_id = mplan.mplan_id
join meal on meal.meal_id = meal_mplan.meal_id
join meal_recipe on meal_recipe.meal_id = meal_mplan.meal_id
join recipe on recipe.recipe_id = meal_recipe.recipe_id
where mplan.mplan_id = 1
order by meal_day, meal_time, recipe_name

--Get everything for one meal plan
select mplan.mplan_id, mplan_name, mplan.user_id,
	meal.meal_id, meal_name, meal_day, meal_time,
	recipe.recipe_id, recipe_name, description, is_public, rating,
		serves, prep_time, cook_time, total_time, utensils,
		instructions, img_url, submitted_by,
	ingredient.ingredient_id, ingredient_name, qty, unit_name
from mplan
join meal_mplan on meal_mplan.mplan_id = mplan.mplan_id
join meal on meal.meal_id = meal_mplan.meal_id
join meal_recipe on meal_recipe.meal_id = meal_mplan.meal_id
join recipe on recipe.recipe_id = meal_recipe.recipe_id
join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = meal_recipe.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where mplan.mplan_id = 1
order by meal_day, meal_time, recipe.recipe_id, ingredient.ingredient_name;

--Get all ids for one meal plan
select mplan.mplan_id, meal.meal_id,
	recipe.recipe_id, 
	ingredient.ingredient_id, ingredient_name
from mplan
join meal_mplan on meal_mplan.mplan_id = mplan.mplan_id
join meal on meal.meal_id = meal_mplan.meal_id
join meal_recipe on meal_recipe.meal_id = meal_mplan.meal_id
join recipe on recipe.recipe_id = meal_recipe.recipe_id
join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = meal_recipe.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where mplan.mplan_id = 1
order by meal.meal_id, recipe.recipe_id, ingredient.ingredient_name;
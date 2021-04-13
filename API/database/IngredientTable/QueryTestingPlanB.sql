USE final_capstone
GO

--in CRUD, Create, Read, Update, Delete oreder, starting from Plan

--================
--===   Plan   === 
--================
--CreatePlan
begin transaction;

insert into mplan (mplan_name, user_id)
values ('test plan', 1); --(@mplan_name, @user_id);
select scope_Identity();

insert into meal_mplan (meal_id, mplan_id, meal_day, meal_time)
values (1, SCOPE_IDENTITY(), 'monday', 'breakfast'); --(@meal_id{i}, @mplan_id{i}, @meal_day{i}, @meal_time{i})

rollback transaction;

--GetPlans
select mplan_id, mplan_name, user_id
from mplan;

--GetPlan
select * from meal_mplan where mplan_id = 6;

select mplan.mplan_id, mplan_name, mplan.user_id,
	meal.meal_id, meal_name, meal_day, meal_time,
	recipe.recipe_id, recipe_name, description, is_public, rating,
		serves, prep_time, cook_time, total_time, utensils,
		instructions, img_url, submitted_by,
	ingredient.ingredient_id, ingredient_name, qty, unit_name
from mplan
left join meal_mplan on meal_mplan.mplan_id = mplan.mplan_id
left join meal on meal.meal_id = meal_mplan.meal_id
left join meal_recipe on meal_recipe.meal_id = meal_mplan.meal_id
left join recipe on recipe.recipe_id = meal_recipe.recipe_id
left join ingredient_recipe_unit on ingredient_recipe_unit.recipe_id = meal_recipe.recipe_id
left join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
left join unit on unit.unit_id = ingredient_recipe_unit.unit_id
where mplan.mplan_id = 1
order by meal_day, meal_time, recipe.recipe_id, ingredient.ingredient_name;

select * from mplan
left join meal_mplan on meal_mplan.mplan_id = mplan.mplan_id
where mplan.mplan_id = 6;

--GetGroceryList
--Sum same ingredient same unit
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

--Update Meal Plan
begin transaction;

update mplan
set mplan_name = 'something old this week'
where mplan_id = 
(select mplan_id from mplan where mplan_name = 'something new this week');

select * from meal_mplan
order by mplan_id, meal_day, meal_time;

update meal_mplan
set meal_id = (select meal_id from meal where meal_name = 'bananas for breakfast'),
	meal_day = 'tuesday',
	meal_time = 'lunch'
where mplan_id = 
(select mplan_id from mplan where mplan_name = 'something old this week');

select * from meal_mplan
order by mplan_id, meal_day, meal_time;

rollback transaction;

--DeleteMealFromMealPlan
begin transaction;

select *
from meal_mplan
where mplan_id = 1
order by meal_day, meal_time;

delete from meal_mplan
where meal_id = 5 and
mplan_id = 1 and
meal_day = 'monday' and
meal_time = 'breakfast';

select *
from meal_mplan
where mplan_id = 1
order by meal_day, meal_time;

rollback transaction;

select recipe_name, is_public, serves, prep_time, cook_time, total_time,
	utensils, instructions, img_url
from recipe
where recipe_id = (select recipe_id from recipe where recipe_name like 'fruit');

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

begin transaction;
--Insert ingredients into recipes
insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'unsweetened chocolate'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'raisins'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tbs'), 2);

rollback transaction;

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
where mplan.mplan_id = 2
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

select * from mplan;

--Insert Meal Plan
insert into mplan (mplan_name, user_id)
values ('something new this week',
		(select user_id from users where username = 'user'));

insert into meal_mplan (meal_id, mplan_id, meal_day, meal_time)
values ((select meal_id from meal where meal_name = 'breakfast of champions'),
		(select mplan_id from mplan where mplan_name = 'something new this week'), 'monday', 'breakfast');

--DeleteRecipeFromMeal
begin transaction;

select *
from meal_recipe;

delete from meal_recipe
where meal_id = 1 and
recipe_id = 3;

select *
from meal_recipe;

rollback transaction;

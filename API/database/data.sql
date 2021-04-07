USE final_capstone
GO
/
--Insert some recipes
insert into recipe (recipe_name, is_public, servings,
	ingredients, utensils, instructions, img_url)
values ('banana bread', 1, 8,
	'[{"name": "banana", "qty": "6ea"}, {"name": "flour", "qty": "4cups"}, {"name": "butter", "qty": "1stick"}]',
	'["mixing bowl", "mixer", "bread pan"]',
	'["thaw bananas", "mix bananas, butter, and flour", "pour in bread pan", "bake in oven at 350, for one hour"]',
	'https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/4/13/0/GC_banana-bread_s4x3.jpg.rend.hgtvcom.826.620.suffix/1371592847747.jpeg');

insert into recipe (recipe_name, is_public, servings,
	ingredients, utensils, instructions, img_url)
values ('zucchini bread', 1, 8, 
	'[{"name": "zucchini", "qty": "6ea"}, {"name": "flour", "qty": "4cups"}, {"name": "butter", "qty": "1stick"}]',
	'["mixing bowl", "mixer", "bread pan"]',
	'["slice zucchini", "mix zucchini, butter, and flour", "pour in bread pan", "bake in oven at 350, for one hour"]',
	'https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F1181288.jpg&w=1200&h=678&c=sc&poi=face&q=85');

--Add the recipes to user
insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'banana bread'),
		(select user_id from users where username = 'user'));

insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'zucchini bread'),
		(select user_id from users where username = 'user'));

--Insert some categories
insert into category (category_name)
values ('quick bread');

insert into category (category_name)
values ('dinner');

insert into category (category_name)
values ('breakfast');

--Add the categories to the recipes
insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='quick bread'),
		(select recipe_id from recipe where recipe_name = 'banana bread'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='quick bread'),
		(select recipe_id from recipe where recipe_name = 'zucchini bread'));

--Add a meal
insert into meal (meal_name, user_id)
values ('breakfast of champions', 1);

insert into meal (meal_name, user_id)
values ('just another lunch', 1);

--Add a recipe to a meal
insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'breakfast of champions'),
		(select recipe_id from recipe where recipe_name = 'banana bread'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'breakfast of champions'),
		(select recipe_id from recipe where recipe_name = 'zucchini bread'));

--Add a meal plan
insert into mplan (mplan_name, user_id)
values ('empty the freezer of bananas',
		(select user_id from users where username = 'user'));

--Add meal to meal plan
insert into meal_mplan (meal_id, mplan_id)
values ((select meal_id from meal where meal_name = 'breakfast of champions'),
		(select mplan_id from mplan where mplan_name like '%bananas%'));

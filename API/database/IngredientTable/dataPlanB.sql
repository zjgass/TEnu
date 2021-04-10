USE final_capstone
GO

--Insert some ingredients
insert into ingredient (ingredient_name)
values ('banana'), ('flour'), ('zucchini'), ('butter'),
		('eggs'), ('olive oil'), ('chia seeds'), ('maraschino cherries'), ('salt'), ('pepper'),
		('ground beef'), ('bell pepper'), ('onion'), ('garlic'), ('tomato sauce'), ('tomato paste'), ('crushed tomato'), ('fresh oregano'), ('fresh parsery'), ('italian seasoning'), ('garlic salt'), ('lasgna noodles'), ('ricotta cheese'), ('mozzarella cheese'), ('parmesan cheese'),
		('cherry tomatos'), ('couscous'), ('chickpea'), ('lemon juice'), ('fresh herb'), ('cucumber'), ('feta cheese');
--Insert some units
insert into unit (unit_name)
values ('cups'), ('tbs'), ('tsp'), ('oz'), ('qt'), ('g'), ('mg'), ('ml'), ('ea'), ('pound'), ('can'), ('cloves'), ('pinch') ;

--Insert some recipes
insert into recipe (recipe_name, description, is_public, rating, serves,
	utensils, instructions, img_url)
values ('banana bread', 'my mother''s recipe, the best!', 1, 5, 8,
	'{utensils: ["mixing bowl", "mixer", "bread pan"]}',
	'{instructions: ["thaw bananas", "mix bananas, butter, and flour", "pour in bread pan", "bake in oven at 350, for one hour"]}',
	'https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/4/13/0/GC_banana-bread_s4x3.jpg.rend.hgtvcom.826.620.suffix/1371592847747.jpeg');

insert into recipe (recipe_name, description, is_public, rating, serves,
	utensils, instructions, img_url)
values ('zucchini bread', 'christina''s recipe, the best!', 1, 5, 8,
	'{utensils: ["mixing bowl", "mixer", "bread pan"]}',
	'{instructions: ["slice zucchini", "mix zucchini, butter, and flour", "pour in bread pan", "bake in oven at 350, for one hour"]}',
	'https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F1181288.jpg&w=1200&h=678&c=sc&poi=face&q=85');

insert into recipe (recipe_name, description, is_public, rating, serves, prep_time,cook_time,total_time,
	utensils, instructions, img_url)
values ('lasagna', 'best lasagna in the world', 1, 5, 8, '15 mins', '90 mins', '105 mins',
	'{utensils: ["skillet", "midium sized pot", "9 x 13-inch casserole dish"]}',
	'{instructions: ["brown the ground beef, set aside", "cook bell pepper, onoions, garlic, add back the beef", "transfer to medium sized pot, add tomatos, tomato sauce, tomato paste, parsrly, oregano, italian seasoning, sprinkle with garlic salt, sprinkle with red or white wine vinegar, bring to simmer and lower the heat, cook for 15 to 45 mins", "boil and drain the lasagna noodles", "assemble the lasagna with sauce, cheese, pasta in a casserole dish", "bake at 375F for 45 mins"  ]}',
	'https://www.simplyrecipes.com/thmb/dWEVorTSuZUmOYPr6pxk4SnK_F8=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2004__12__lasagna-horiz-a-2000-a4631232672d4609b12b94da7a20ef90.jpg');

insert into recipe (recipe_name, description, is_public, rating, serves, prep_time,cook_time,total_time,
	utensils, instructions, img_url)
values ('Couscous Salad', 'perfect for lunch', 1, 5, 8, '20 mins', '20mins', '40 mins',
	'{utensils: ["mixing bowl"]}',
	'{instructions: ["roast half of tomatos", "cook pearl couscous", "make roasted chickpeas", "mix fresh tomato, roasted tomato, couscous, chickpeas, olive oil, lemon juice, garlic, fresh hearbs, cucumbers, feta cheese"]}',
	'https://www.wellplated.com/wp-content/uploads/2016/07/Israeli-Couscous-Salad-Feta.jpg');

--Add the recipes to user
insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'banana bread'),
		(select user_id from users where username = 'user'));

insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'zucchini bread'),
		(select user_id from users where username = 'user'));

insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'lasagna'),
		(select user_id from users where username = 'user'));

insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select user_id from users where username = 'user'));

--Add ingredients to recipe
insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'banana'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'ea'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'flour'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'olive oil'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tbs'), 3);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'zucchini'),
		(select recipe_id from recipe where recipe_name = 'zucchini bread'),
		(select unit_id from unit where unit_name = 'ea'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'flour'),
		(select recipe_id from recipe where recipe_name = 'zucchini bread'),
		(select unit_id from unit where unit_name = 'ea'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'olive oil'),
		(select recipe_id from recipe where recipe_name = 'zucchini bread'),
		(select unit_id from unit where unit_name = 'tbs'), 3);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'ground beef'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'pound'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'onion'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'cups'), 0.5),
		((select ingredient_id from ingredient where ingredient_name = 'olive oil'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'tbs'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'bell pepper'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'cups'), 0.75),
		((select ingredient_id from ingredient where ingredient_name = 'garlic'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'cloves'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'tomato sauce'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'can'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'tomato paste'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'can'), 0.5),
		((select ingredient_id from ingredient where ingredient_name = 'crushed tomato'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'can'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'fresh oregano'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'tbs'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'fresh parsely'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'cup'), 0.75),
		((select ingredient_id from ingredient where ingredient_name = 'italian seasoning'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'tbs'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'garlic salt'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'pinch'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'wine vinegar'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'tbs'), 1),
        ((select ingredient_id from ingredient where ingredient_name = 'lasagna noodles'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'pound'), 0.5),
        ((select ingredient_id from ingredient where ingredient_name = 'ricotta cheese'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'oz'), 15),
		((select ingredient_id from ingredient where ingredient_name = 'mozzarella cheese'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'oz'), 24),
		((select ingredient_id from ingredient where ingredient_name = 'parmesan cheese'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'oz'), 4);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'cherry tomatos'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'ea'), 8),
		((select ingredient_id from ingredient where ingredient_name = 'couscous'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'cups'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'chick pea'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'cups'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'cucumber'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'ea'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'olive oil'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'tbs'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'lemonjuice'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'tbs'), 3),
		((select ingredient_id from ingredient where ingredient_name = 'feta cheese'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'oz'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'fresh herb'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'cups'), 0.5),
        ((select ingredient_id from ingredient where ingredient_name = 'garlic'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'tbs'), 1.5);

--Insert some categories
insert into category (category_name)
values ('quick bread');

insert into category (category_name)
values ('dinner');

insert into category (category_name)
values ('breakfast');

insert into category (category_name)
values ('lunch');

--Add the categories to the recipes
insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='quick bread'),
		(select recipe_id from recipe where recipe_name = 'banana bread'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='quick bread'),
		(select recipe_id from recipe where recipe_name = 'zucchini bread'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='dinner'),
		(select recipe_id from recipe where recipe_name = 'lasagna'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='lunch'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'));

--Add a meal
insert into meal (meal_name, user_id)
values ('breakfast of champions',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('just another lunch',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('best lasagna in the world',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('perfect for lunch',
		(select user_id from users where username = 'user'));

--Add a recipe to a meal
insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'breakfast of champions'),
		(select recipe_id from recipe where recipe_name = 'banana bread'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'breakfast of champions'),
		(select recipe_id from recipe where recipe_name = 'zucchini bread'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'best lasagna in the world'),
		(select recipe_id from recipe where recipe_name = 'lasagna'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'perfect for lunch'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'));

--Add a meal plan
insert into mplan (mplan_name, user_id)
values ('empty the freezer of bananas',
		(select user_id from users where username = 'user'));

--Add meal to meal plan
insert into meal_mplan (meal_id, mplan_id, meal_day, meal_time)
values ((select meal_id from meal where meal_name = 'breakfast of champions'),
		(select mplan_id from mplan where mplan_name like '%bananas%'), 'monday', 'breakfast');

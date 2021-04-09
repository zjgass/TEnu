USE final_capstone
GO

--Insert some ingredients
insert into ingredient (ingredient_name)
values ('banana'), ('flour'), ('zucchini'), ('butter'),
		('eggs'), ('olive oil'), ('chia seeds'), ('maraschino cherries'),

		('sugar'), ('coconut oil'), ('baking soda'), ('baking powder'),
		('mandarin oranges'), ('semi-sweet chocolate chips'), ('canola oil'),
		('zucchini'), ('brown sugar'), ('cinnamon'), ('nutmeg'),
		('unsweetened chocolate'), ('allspice'), ('cloves'), ('ginger');

--Insert some units
insert into unit (unit_name)
values ('cups'), ('tbs'), ('tsp'), ('oz'), ('fl oz'), ('qt'), ('pt'), ('qt'), ('gal'), 
('g'), ('mg'), ('ml'),
('ea'), ('to taste');

--Insert some recipes
insert into recipe (recipe_name, description, is_public, rating, serves,
	utensils, instructions, img_url, submitted_by)
values ('banana bread', 'my mother''s recipe, the best!', 1, 5, 8,
	'{utensils: ["mixing bowl", "mixer", "bread pan", "oven"]}',
	'{instructions: ["thaw bananas", "mix all ingredients together", "pour in bread pan", "bake in oven at 350F, check every half-hour"]}',
	'https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/4/13/0/GC_banana-bread_s4x3.jpg.rend.hgtvcom.826.620.suffix/1371592847747.jpeg', 1);

insert into recipe (recipe_name, description, is_public, rating, serves,
	utensils, instructions, img_url)
values ('chocolate zucchini bread', 'christina''s recipe, the best!', 1, 5, 8,
	'{utensils: ["mixing bowl", "mixer", "2 bread pan", "oven"]}',
	'{instructions: ["Preheat oven to 350F.", "Grease pans.",
	"In large bowl, combine flour, baking powder, baking soda, allspice, cinnamon, cloves, and salt. Set aside.",
	"In large mixing bowl with mixer at medium speed, beat oil and sugar.",
	"Add eggs to oil and sugar mixture, one at a time.",
	"Gradually beat in melted chocolate.",
	"Add dry ingredients and beat until smooth.",
	"Fold in shredded zucchini, chocolate chips, and pecans.",
	"Pour into greased and floured pan.",
	"Bake for 1 hour and 20 minuted or until toothpick comes out clean.",
	"Cool in pan for 20 minutes before removing.",]}',
	'https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F1181288.jpg&w=1200&h=678&c=sc&poi=face&q=85');

--Add the recipes to user
insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'banana bread'),
		(select user_id from users where username = 'user'));

insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select user_id from users where username = 'user'));

--Add ingredients to recipe
insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'banana'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'ea'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'sugar'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 0.75),
		((select ingredient_id from ingredient where ingredient_name = 'chia seeds'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tbs'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'flour'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'coconut oil'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tbs'), 3),
		((select ingredient_id from ingredient where ingredient_name = 'baking soda'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tps'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'salt'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tps'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'manderin oranges'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'maraschino cherries'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'semi-sweet chocolate chips'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'zucchini'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 3),
		((select ingredient_id from ingredient where ingredient_name = 'brown sugar'),
		(select recipe_id from recipe where recipe_name = 'zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 2.33),
		((select ingredient_id from ingredient where ingredient_name = 'eggs'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'ea'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'flour'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 3),
		((select ingredient_id from ingredient where ingredient_name = 'canola oil'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'baking soda'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'baking powder'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'salt'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1.25),
		((select ingredient_id from ingredient where ingredient_name = 'unsweetened chocolate'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'oz'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'semi-sweet chocolate chips'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cup'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'allspice'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 0.25),
		((select ingredient_id from ingredient where ingredient_name = 'allspice'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 0.25),
		((select ingredient_id from ingredient where ingredient_name = 'cinnamon'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'chopped pecans'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 1);

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
values ('breakfast of champions',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('just another lunch',
		(select user_id from users where username = 'user'));

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
insert into meal_mplan (meal_id, mplan_id, meal_day, meal_time)
values ((select meal_id from meal where meal_name = 'breakfast of champions'),
		(select mplan_id from mplan where mplan_name like '%bananas%'), 'monday', 'breakfast');

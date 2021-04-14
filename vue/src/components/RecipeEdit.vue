<template>
    <div id='detail-box'>
        
        <div id='recipe-box'>
        <h1 id='recipe-title'>{{recipe.name}}</h1>
        <button v-on:click.prevent="saveRecipe()"> Save Changes </button>
        <input class="input-short-text" type='text' v-model="recipe.name"/>
        <h2>serves: {{recipe.serves}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.serves"/>
        <h2>prep time: {{recipe.prepTime}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.prepTime"/>
        <h2>cook time: {{recipe.cookTime}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.cookTime"/>
        <h2>total time: {{recipe.totalTime}}</h2>
        <input class="input-short-text" type='text' v-model="recipe.totalTime"/>
        <h2>ingredients:</h2>
        <div class='input-line'>
                <button v-on:click.prevent="showIngredients()">Select Ingredient</button>
                <button v-on:click.prevent="clearIngredients()">Clear Ingredients</button>
            </div>
            <div class='input-line'>
                <h3 >{{newIngredient.name}}</h3>
                <h3 class="input-label">  Quantity: </h3>
                <input class="input-integer-text" type='text' v-model="newIngredient.qty" />
                <h3 class="input-label">  Measurement: </h3>
                <select class="input-select-dropdown" v-model="newIngredient.unit">
                    <option value="pinch"> pinch </option>
                    <option value="tsp"> tsp </option>
                    <option value="tbs"> tbs </option>
                    <option value="cups"> cups </option>
                    <option value="oz"> oz </option>
                    <option value="lb"> lb </option>
                    <option value="fl oz"> fl oz </option>
                    <option value="pt"> pt </option>
                    <option value="qt"> qt </option>
                    <option value="gal"> gal </option>
                    <option value="mg"> mg </option>
                    <option value="g"> g </option>
                    <option value="ml"> ml </option>
                    <option value="l"> l </option>
                    <option value="ea"> ea </option>
                    <option value="to taste"> to taste </option>
                    <option value="cloves"> cloves </option>
                    <option value="can"> can </option>
                </select>
                <button class="add-button" v-on:click.prevent='addIngredient()'>Add</button>
            </div>
        <ul>

            <div class='ingredient-line' v-for="item in recipe.ingredients" :key="item" >
                <p class="buttons" v-on:click="deleteIngredient(item)"> x </p>
                <li class='ingredient-name-in-line'>{{ item.name }} Qty: {{item.qty}} {{item.unit}}</li>
            </div>

        </ul>
        <h2>utensils: </h2>
            <!--<li v-for="item in recipe.utensils" :key="item"> {{item}}</li>-->
        <h2>instructions: {{recipe.instructions}}</h2>
        </div>

      <!-- <tr v-for="recipe in Recipes" :key="recipe.recipeId" > -->
<div id='image-box'>
    <img src="recipe.imgUrl" alt='image of completed recipe' />




    </div>


    </div>
</template>


<script>
import recipeService from '@/services/RecipeService';
import ingredientService from "../services/IngredientService";

export default {
    name: 'recipe-edit',
    ingredients: [],
    data(){
        return {
            showDetails: true,
            storeLoaded: false,
            newIngredient: [],
            recipe: []
           
        }
    },
    computed: {
   
    },
    methods:{
        loadIngredients(){
            ingredientService.getIngredients()
            .then(response => {
                console.log(response.status); 
                    this.ingredients = response.data;       
                    console.log('Ingredients Loaded');
                }
            )
            .catch(error => {
                if(error.response){
                    this.errorMsg = "Error loading all existing recipes.  Response received was '" + error.response.statusTest + "'.";
                    console.log('load failed');
                }
            })

        },
        showIngredients(){
            this.showDetails = false;
            if(this.storeLoaded === false){
                  this.$store.commit("ADD_INGREDIENTS", this.ingredients);
                  console.log('test method commit ingredients');
                  this.storeLoaded = true;
            }     
        },
        clearIngredients(){
            this.recipe.ingredients = [];
        },
        addIngredient(){
            this.showDetails = true;
            this.recipe.ingredients.push(this.newIngredient);
            this.recipe.newIngredient = [];
        },
        saveRecipe(){
         recipeService.updateRecipe(this.recipe)
         .then(response => {
             if(response.status === 200){
                 console.log('recipe updated succesfully');
             }
         })
         .catch(error => {
                if(error.response) {
                    console.log('error saving recipe')
                    this.errorMsg = "Error creating updating Recipe. Response received was '" + error.response.statusText + "'.";
                }
            })
        },
        deleteIngredient(item){
           console.log("Attempting to delete ingredient."); 
           this.recipe.ingredients.splice((this.recipe.ingredients.indexOf(item)),1);
        }
    },
    created() {
        this.loadIngredients();
        console.log('loaded recipeform');
        console.log("Started loading recipe to edit.")
        recipeService.getRecipe(this.$route.params.idedit)
                    .then(response => {
                    this.recipe =  response.data;
            });
    }

}


</script>

<style scoped>

.ingredient-line{
list-style-type: none;
display: flex;
flex-direction: row;
height: 34px;
margin-bottom: 5px;
}
.buttons{
    text-align: center;
    font-size: 24pt;
    width: 30px;
    height: 30px;
    color: red;
    cursor: pointer;

    margin-top: 0px;
}

.ingredient-name-in-line{
    width: 80%;

    margin-top: 5px;
    font-size: 24px;

}

#recipe-title{
text-decoration: underline;
margin-top: 0px;
text-transform: capitalize;

}

#recipe-box, #image-box{
    /* border: 1px solid black; */
    width: 45%;
    padding: 10px;
    box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border-radius: 5px;

}
#detail-box{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    min-height: 600px;

}
#image-box{
    height: 600px;
    box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border-radius: 5px;
}

ul{
    padding: 0px;
}


</style>
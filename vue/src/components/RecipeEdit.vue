<template>
    <div id='detail-box'>
        
        <div id='recipe-box'>

        <div id='title-and-save-button'>
        <h1 id='recipe-title'>{{recipe.name}}</h1>
        <button id='save-button' v-on:click.prevent="saveRecipe()"> Save Changes </button>
        </div>


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



            <select class='ingredient-dropdown'>
                    <option v-for="ingredient in this.$store.state.existingIngredients"                    
                v-bind:key="ingredient.ingredientId"
                v-bind:ingredient="ingredient"
                > {{ ingredient.name }}</option>
            </select>



                <!-- <button v-on:click.prevent="showIngredients()">Select Ingredient</button>
                <button v-on:click.prevent="clearIngredients()">Clear Ingredients</button> -->
            </div>
            <div class='input-line'>

                <!-- <select class="input-selection-dropdown" v-model="newIngredient.name">
                    <option v-for="ingredient in this.$store.state.existingIngredient" :key="ingredient.ingredientId" v-bind:ingredient="ingredient" value="ingredient">{{ingredient.name}}</option>
                </select> -->





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


            <li class='current-ingredient-list-item' v-for="item in recipe.ingredients" :key="item" >
                <p class="buttons" v-on:click="deleteIngredient(item)"> x </p>
                <p class='ingredient-name-in-line'>{{ item.name }}</p>
                Qty:  <input class="input-integer-text" type='text' v-model="item.qty" />
                 Unit: <select class="input-select-dropdown" v-model="item.unit">
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
            </li>
        </ul>

        <h2>utensils:</h2>
            <ul>
                <li v-for="item in recipe.utensils" :key="item"> {{item}}
                    <p class="buttons" v-on:click.prevent="deleteUtensil(item)"> x </p>
                </li>
            </ul>
            
        <h2>instructions:</h2>
            <input class="input-text" type='text' v-model="newInstruction" />
            <input class="input-integer-text" type='text' v-model="newInstructionAt" />
            <button class="add-button" v-on:click.prevent='insertInstructionAt()'>Add</button>
            <ol>
                <li v-for="item in recipe.instructions" :key="item"> {{item}}
                    <p class="buttons" v-on:click.prevent="deleteInstruction(item)"> x </p> 
                </li>
            </ol>

        <h2>categories: </h2>
        <select class='category-dropdown'>
                    <option v-for="category in this.$store.state.existingCategories"                    
                v-bind:key="category.categoryId"
                v-bind:category="category"
                > {{ category.name }}</option>
            </select>
        <div v-for="item in recipe.categories" :key="item">{{ item.name }} <p class="buttons" v-on:click.prevent="deleteCategory(item)"> x </p></div>
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
import categoryService from "../services/CategoryService";

export default {
    name: 'recipe-edit',
    ingredients: [],
    categories: [],
    data(){
        return {
            showDetails: true,
            storeLoaded: false,
            newInstruction: "",
            newInstructionAt: 0,
            newIngredient: [],
            newCategory: [],
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
                    this.errorMsg = "Error loading all existing ingredients.  Response received was '" + error.response.statusTest + "'.";
                    console.log('load failed');
                }
            })

        },
        loadCategories(){
            categoryService.getCategories()
            .then(response => {
                console.log(response.status); 
                    this.categories = response.data;       
                    console.log('Categories Loaded');
                }
            )
            .catch(error => {
                if(error.response){
                    this.errorMsg = "Error loading all existing categories.  Response received was '" + error.response.statusTest + "'.";
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
        insertInstructionAt(){
            this.recipe.instructions.splice(this.newInstructionAt-1,0,this.newInstruction);
            this.newInstruction = '';
            this.newInstructionAt = this.recipe.instructions.count();
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
        },
        deleteUtensil(item){
            console.log("Attempting to delete utensil.");
            this.recipe.utensils.splice((this.recipe.utensils.indexOf(item)),1);
        },
        deleteInstruction(item){
            console.log("Attempting to delete instruction.");
            this.recipe.instructions.splice((this.recipe.instructions.indexOf(item)),1);
        },
        deleteCategory(item){
            console.log("Attempting to delete instruction.");
            this.recipe.categories.splice((this.recipe.categories.indexOf(item)),1);
        }
    },
    created() {
        this.loadIngredients();
        this.loadCategories();
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

.current-ingredient-list-item{
list-style-type: none;
display: flex;
flex-direction: row;
height: auto;
min-height: 34px;
margin-bottom: 5px;
/* background-color: silver; */
}

.buttons{
    text-align: center;
    font-size: 24pt;
    width: 30px;
    height: 30px;
    color: red;
    cursor: pointer;
    margin-top: 0px;
    margin-bottom: 0px;
}

.input-select-dropdown{
    height: 34px;
}

.ingredient-name-in-line{
    width: 60%;
    height: auto;
    margin-top: 5px;
    font-size: 24px;
    margin-bottom: 0px;

}


#title-and-save-button{


    display: flex;
    flex-direction: row;
    justify-content: space-between;
}

#recipe-title{
text-decoration: underline;
margin-top: 0px;
text-transform: capitalize;
width: 65

}
#save-button{
    width: 30%;
    height: 30px;
    font-size: 16pt;
    cursor: pointer;

}


#recipe-box, #image-box{
    /* border: 1px solid black; */
    width: 45%;
    padding: 10px;
    box-shadow:0 4px 8px 0 darkcyan, 0 6px 20px 0 rgba(0, 0, 0, 0.19);
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
    box-shadow:0 4px 8px 0 darkcyan, 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border-radius: 5px;
}

ul{
    padding: 0px;
}
.ingredient-dropdown{
    height: 50px;
    font-size: 20pt;
    width: 100%;
}


@media(max-width: 1400px) {
#recipe-box, #image-box{

width: 95%;
width: 95%;
margin: 10px auto;

}
#detail-box{
    display:flex;
    flex-direction: column;
}

}

</style>
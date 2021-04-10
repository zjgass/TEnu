<template>
    <div>
        <div id='form-page'>

        <form id='recipe-input' action="" method="">

            <div class='input-line'>
                <p class='input-label'>Recipe Name: </p>
                <input class="input-short-text" type='text' v-model="recipe.name"  />              
            </div>
            
            <div class='input-line'>
                <p class='input-label'>Description: </p>
                <input class="input-description-text" type='text' v-model="recipe.description" />
            </div>

            <div class='input-line'>
                <p class='input-label'>Serves: </p>
                <input class="input-integer-text" type='text' v-model="recipe.serves" />
           
                <p class='input-label'>Prep Time:  </p>
                <input class="input-integer-text" type='text' v-model="recipe.prepTime" />
           
                <p class='input-label'>Cook Time: </p>
                <input class="input-integer-text" type='text' v-model="recipe.cookTime" />
            </div>

            <div class='input-line'>
                <p class='input-label'>Utensils Needed: </p>
                <input type='text' v-model="newUtensil"  />
                <button v-on:click.prevent="addUtensil()">Add Utensil</button>
                <button v-on:click.prevent="clearUtensils()">Clear Utensils</button>
            </div>

            <div class='input-line'>
                <p class='input-label'>Instructions: </p>
                <input type='text' v-model="newInstruction"/>
                <button v-on:click.prevent="addInstruction()">Add Step</button>
                <button v-on:click.prevent="clearInstructions()">Clear Steps</button>
            </div>

            <div class='input-line'>
                <button v-on:click.prevent="showIngredients()">Add Ingredient</button>
                <button v-on:click.prevent="clearIngredients()">Clear Ingredients</button>
            </div>

            <button id='submit-button' v-on:click.prevent='saveRecipe()'>Submit Recipe</button>
        </form>


        <!--Use v-if here to display current details entered or if
        user has clicked add ingredient button display AddIngredientComponent -->

        <div class="show-recipe-details" v-if="showDetails">
            <div class="instruction-list">
                
            </div>
        </div>



        <div class="show-add-ingredient" v-if="!showDetails">
             <div class="ingredient-list" v-for="ingredient in this.$store.state.existingIngredients"                    
                v-bind:key="ingredient.ingredientId"
                v-bind:ingredient="ingredient"
                >
                <h3>{{ingredient.name}}  Quantity: </h3>
                <input class="input-integer-text" type='text' v-model="ingredient.qty" />
                <h3>  Measurement: </h3>
                <select v-model="ingredient.unit">
                    <option value="cups"> cups </option>
                    <option value="ea"> ea </option>
                    <option value="g"> g </option>
                    <option value="mg"> mg </option>
                    <option value="ml"> ml </option>
                    <option value="oz"> oz </option>
                    <option value="qt"> qt </option>
                    <option value="tbs"> tbs </option>
                    <option value="tsp"> tsp </option>
                </select>

                <button id='add-this-ingredient' v-on:click.prevent="addIngredient(ingredient)">Add </button>

            </div>  
        </div>



    </div>
</div>
</template>

<script>

import recipeService from "../services/RecipeService";
import ingredientService from "../services/IngredientService";

export default {
    name: "recipe-form",
    data() {
        return {
            showDetails: true,
            storeLoaded: false,
            ingredients: [],   
            newInstruction: "",    
            newUtensil: "",   
            recipe: {
               // recipeId: 0, 
                name: "",
                isPublic: true,
                description: "",
                serves: "",
                prepTime: "",
                cookTime: "",
                totalTime: "",
                ingredients: [],
                utensils: "",
                instructions: "",
                imgUrl: "",
                submittedBy: "",
                rating: 0
            }
        };
    },
    
    created(){
        this.loadIngredients();
        console.log('loaded recipeform');   
    },
    methods: {
        addInstruction(){
            this.recipe.instructions += this.newInstruction + ",";
            this.newInstruction = "";
         },
        addUtensil(){
            this.recipe.utensils += this.newUtensil + ",";
            this.newUtensil = "";
        }, 
        saveRecipe() {
            recipeService.addRecipe(this.recipe)
            .then(response => {
                if(response.status === 201){
                    console.log('recipe saved succesfully');
                }
            })
            .catch(error => {
                if(error.response) {
                    console.log('error saving recipe')
                    this.errorMsg = "Error creating new Recipe. Response received was '" + error.response.statusText + "'.";
                }
            })
        },
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
        addIngredient(ingredient){
            this.showDetails = true;
            this.recipe.ingredients.push(ingredient);
        },
        clearIngredients(){
            this.recipe.ingredients = [];
        },
        clearUtensils(){
            this.recipe.utensils = "";
        },
        clearInstructions() {
            this.recipe.instructions = "";
        }
        
        
    },
    

}
</script>

<style>



li, p{
    font-size: 16pt;
}



h2{
    margin-top: 0px
}

.input-line{
    
    display: flex;



    padding: 10px;
    border-radius: 5px;
    margin-bottom: 10px;
}
.input-label{
    font-size: 1rem;
    margin-top: 0px;
    
}

.input-short-text {
    width: 200px;
    height: 20px;
}

.input-description-text {
    width: 300px;
    height: 40px;
}

.input-integer-text {
    width:20px;
    height: 20px;
    margin: 0px 5px 0px 5px;
}

.ingredient-list{
    display: flex;
}

.ingredient-list>h3{

    font-size: .75rem;
}

#recipe-input{
    border: 1px solid black;
    width: 47%;
    padding: 10px;

    min-height: 300px;
    margin-left: 10px;
    margin: auto;


}

.show-add-ingredient{
    width: 47%;
    min-height: 300px;
    height: auto;
    padding: 10px;
    border: solid 1px black;
}

.show-recipe-details{
    width: 47%;
    min-height: 300px;
    height: auto;
    padding: 10px;
    border: solid 1px black;

}


#current-recipe{

    width: 47%;
    min-height: 300px;
    height: auto;
    padding: 10px;
    border: solid 1px black;
    margin-right: 10px;
        margin: auto;


}
#form-page{

    display: flex;
    justify-content: space-between;
    /* background-color: silver; */
    
}


#submit-button{
    width: 90%;
    height: 30px;
    font-size: 16pt;
    margin-top: 20px;
}

@media(max-width: 1400px) {
#form-page{
display: flex;
flex-direction: column;

}



#recipe-input, #current-recipe{
    margin-bottom: 10px;
    width: 90%;

}}

</style>
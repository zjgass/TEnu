<template>
    <div>
        <div id='title-and-button'>
        <h1>Add A New Recipe</h1>
        <button id='submit-button' v-on:click.prevent='saveRecipe()'>Submit Recipe</button>
    </div>

        <div id='form-page'>

        <form id='recipe-input' action="" method="">
            <h2>New Recipe Info</h2>
            <div class='input-line'>
                <p class='input-label'>Recipe Name: </p>
                <input class="input-box" type='text' v-model="recipe.name"  />              
            </div>
            
            <div class='input-line'>
                <p class='input-label'>Description: </p>
                <input class="input-box" type='text' v-model="recipe.description" />
            </div>

            <div class='input-line'>
                <p class='input-label'>Serves: </p>
                <input class="small-input-box" type='text' v-model="recipe.serves" />
           
                <p class='input-label'>Prep Time:  </p>
                <input class="small-input-box" type='text' v-model="recipe.prepTime" />
           
                <p class='input-label'>Cook Time: </p>
                <input class="small-input-box" type='text' v-model="recipe.cookTime" />
            </div>

            <div class='input-line'>
                <p class='input-label'>Utensils Needed: </p>
                <input class="input-box" type='text' v-model="newUtensil"  />
                <button class='small-non-submit-buttons' v-on:click.prevent="addUtensil()">Add Utensil</button>
                <button class='small-non-submit-buttons' v-on:click.prevent="clearUtensils()">Clear Utensils</button>
            </div>

            <div class='input-line'>
                <p class='input-label'>Instructions: </p>
                <input class="input-box" type='text' v-model="newInstruction"/>
                <button class='small-non-submit-buttons' v-on:click.prevent="addInstruction()">Add Step</button>
                <button class='small-non-submit-buttons' v-on:click.prevent="clearInstructions()">Clear Steps</button>
            </div>

                    <h2>Add Ingredients</h2>

            <div class='input-line'>
                <button class='non-submit-buttons' v-on:click.prevent="showIngredients()">Select Ingredient</button>
                <button class='non-submit-buttons' v-on:click.prevent="clearIngredients()">Clear Ingredients</button>
            </div>

            <div class='input-line'>
                
                <h3 >{{newIngredient.name}}</h3>
                <h3 class="input-label">  Quantity: </h3>
                <input class="input-box" type='text' v-model="newIngredient.qty" />
                <h3 class="input-label">  Measurement: </h3>
                <select  v-model="newIngredient.unit">
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
                <button class='small-non-submit-buttons' v-on:click.prevent='addIngredient()'>Add</button>
            </div>
            


        </form>


        <!--Use v-if here to display current details entered or if
        user has clicked add ingredient button display AddIngredientComponent -->

        <div class="show-recipe-details" v-if="showDetails">
        <h2>Recipe</h2>
        <h1>{{recipe.name}}</h1>
        <p>{{recipe.description}}</p>
        
        <p>Serves: {{recipe.serves}}</p>
        <p>Prep Time: {{recipe.prepTime}} minutes</p>
        <p>Cook Time: {{recipe.cookTime}} minutes</p>
        
        <h3>Instructions</h3>
        <p v-for="item in recipe.instructions" :key="item">{{item}}</p>

        <h3>Ingredients</h3>
        <table>
                <!-- <tr>
                    <th class='table-heading'>Item</th>
                    <th class='table-heading'>Column 2</th>
                    <th class='table-heading'>Column 3</th>
                </tr> -->
                <tr v-for='item in recipe.ingredients' 
                    v-bind:key='item.name'>              
                    <td>{{item.name}}</td>
                    <td>{{item.qty}}</td>
                    <td>{{item.unit}}</td>
            </tr>
        </table>


    <h3>Utensils Needed</h3>
    <p v-for="item in recipe.utensils" :key="item">{{item}}</p>

            
        </div>



        <div class="show-add-ingredient" v-if="!showDetails">
             <div class="ingredient-list" v-for="ingredient in this.$store.state.existingIngredients"                    
                v-bind:key="ingredient.ingredientId"
                v-bind:ingredient="ingredient"
                >
                <h3 class='ingredient-in-large-list' v-on:click.prevent="selectedIngredient(ingredient)">{{ingredient.name}}  </h3>
        
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
            //ingredients: [],   
            newInstruction: "",    
            newUtensil: "",   
            newIngredient: "",
            recipe: {
                name: "",
                isPublic: true,
                description: "",
                serves: "",
                prepTime: "",
                cookTime: "",
                totalTime: "",
                ingredients: [],
                utensils: [],
                instructions: [],
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
            this.recipe.instructions.push(this.newInstruction.trim());
            this.newInstruction = "";
         },
        addUtensil(){
            this.recipe.utensils.push(this.newUtensil.trim());
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
        addIngredient(){
            this.showDetails = true;
            this.recipe.ingredients.push(this.newIngredient);
            this.newIngredient = "";
        },
        clearIngredients(){
            this.recipe.ingredients = [];
        },
        clearUtensils(){
            this.recipe.utensils = "";
        },
        clearInstructions() {
            this.recipe.instructions = "";
        },
        selectedIngredient(ingredient) {
            this.newIngredient = ingredient;
            this.showDetails = true;
            
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




/* bookmark */
/* bookmark */
/* bookmark */
/* bookmark */
/* bookmark */
/* bookmark */
/* bookmark */


.input-line{
    
    display: flex;
    padding: 10px;
    border-radius: 5px;
    margin-bottom: 10px;
    
}


.input-label{
    font-size: 18pt;
    margin-top: 0px;
    width: auto;
    margin-right: 10px;

    
}

.non-submit-buttons{
height: 38px;
width: 200px;
font-size: 12pt;

}

.small-non-submit-buttons{
padding: 0px;
height: 38px;
width: 150px;
font-size: 12pt;

}


.input-box {
height: 24pt;
width: 200px;
border: none;
border-bottom: 2px darkcyan solid;
outline: none;
font-size: 20pt;

}

.small-input-box {
height: 24pt;
width: 60px;
border: none;
border-bottom: 2px darkcyan solid;
outline: none;
font-size: 20pt;
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

    font-size: 12pt;
    cursor: pointer;
    text-transform: capitalize;
    margin-bottom: 0px;

}



#recipe-input{
  box-shadow:0 4px 8px 0 darkcyan, 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  border-radius: 5px;
    width: 45%;
    padding: 20px;

    min-height: 1000px;



}

#recipe-input h2{
    background-color: darkcyan;
    color: white;
    padding: 10px;
    text-align: center;

}

.show-recipe-details h2{
    background-color: darkcyan;
    color: white;
    padding: 10px;
    text-align: center;



}

.show-add-ingredient{
    width: 45%;
    max-height: 600px;
    height: auto;
    padding: 10px;
  box-shadow:0 4px 8px 0 darkcyan, 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    overflow: scroll;

  border-radius: 5px;
  font-size: 20px;

    

}

.show-recipe-details{
    width: 45%;
    min-height: 300px;
    height: auto;
    padding: 20px;
  box-shadow:0 4px 8px 0 darkcyan, 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    overflow: scroll;
    max-height: 1000px;
    word-wrap: break-word;
  border-radius: 5px;


}

.show-recipe-details h3{
    font-size: 24pt;
}

.show-recipe-details p, tr{
    font-size: 18pt;
}


.show-recipe-details h1{
    font-size: 24pt;
    text-decoration: underline;
    text-transform: capitalize;
    text-align: center;
}




#form-page{

    display: flex;
    justify-content: space-between;

    
}

#title-and-button{

    display: flex;
    flex-direction: row;
    justify-content: space-between;
    
}


#submit-button{
    width: 400px;
    height: 40px;
    font-size: 16pt;
    /* background-color: darkcyan; */
    font-size: 20pt;
    /* color: white; */
    cursor: pointer;
    margin: 10px;
    

}

@media(max-width: 1400px) {
#form-page{
display: flex;
flex-direction: column;
align-content: center;



}

#recipe-input, #current-recipe, .show-recipe-details{
    margin-bottom: 10px;
    width: 95%;


}

#recipe-input h2{
width: 50%;
}

#router-wrapper{
    display: flex;
    flex-direction: row;
    align-content: center;

}






}

</style>
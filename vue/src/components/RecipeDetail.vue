<template>
    <div id='detail-box'>
        
        <div id='recipe-box'>
        <div id='title-and-pencil'>
        <h1 id='recipe-title'>{{recipe.name}}</h1>
        <div class="buttons" v-on:click.prevent>
            <router-link v-bind:to="{name: 'RecipeEditView', params: {idedit : this.$route.params.id}}">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" 
                class="pencil" viewBox="0 0 16 16">
                <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z"/>
            </svg>

            </router-link>
                    </div>
        </div>
        <h2>serves: {{recipe.serves}}</h2>
        <h2>prep time: {{recipe.prepTime}}</h2>
        <h2>cook time: {{recipe.cookTime}}</h2>
        <h2>total time: {{recipe.totalTime}}</h2>
        <h2>ingredients:</h2>
        <ul>
           <li v-for="item in recipe.ingredients" :key="item" >{{ item.name }} Qty: {{item.qty}} {{item.unit}}</li>
        </ul>
        <h2>utensils: </h2>
        <ul>
            <li v-for="item in recipe.utensils" :key="item"> {{item}}</li>
            <!--<p>{{recipe.utensils}}</p> -->
        </ul>
        <h2>instructions:</h2>
        <ol>
            <li v-for="item in recipe.instructions" :key="item"> {{item}} </li>
            <!--<p>{{recipe.instructions}}</p>-->
        </ol>
        <h2>categories: </h2>
        <div id='category' v-for="item in recipe.categories" :key="item">{{ item.name }}</div>
        </div>



<div id='image-box'>
          <img :src='recipe.imgUrl' id='details-image'/>

    

</div>

<!-- <p>{{recipe}}</p> -->
    </div>






</template>


<script>
import recipeService from '@/services/RecipeService';

export default {
    name: 'recipe-detail',
    props: {
        'recipeId' : Number
    },
    data(){
        return {
            recipe: []
           
        }
    },
    computed: {
   
    },
    created() {
        console.log("Started loading recipe details.")
        recipeService.getRecipe(this.$route.params.id)
                    .then(response => {
                    this.recipe =  response.data;
            });
    }

}


</script>

<style scoped>

#recipe-title{
text-decoration: underline;
margin-top: 0px;
text-transform: capitalize;
width: auto;


}
#details-image{
    width: 100%;
    height: 100%;
}

#category{
    font-size: 18pt;
}

#recipe-box, #image-box{
    /* border: 1px solid black; */
    width: 45%;
    padding: 10px;
      box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border-radius: 5px;
    height: auto;

}
#detail-box{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    min-height: 600px;
    height: auto;


}
#image-box{
    height: 50%;
        height: 600px;
}

.pencil{
display: inline;
/* background-color: red; */
width: 30px;
height: 30px;
margin-top: 5px;
margin-left: 20px;

}


#title-and-pencil{
    display: flex;
    width: auto;


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
<template>
<div class="grocery-list">

<h1>Grocery list for</h1>


<table>
   <tr>
    <th class='table-heading'>Ingredient</th>
    <th class='table-heading'>Qty</th>
    <th class='table-heading'>Unit</th>
  </tr> 
  <tr v-for='item in Groceries' 
v-bind:key='item.name'>
    <td>{{item.name}}</td>
    <td>{{item.qty}}</td>
    <td>{{item.unit}}</td>
  </tr>
</table>



<!--
 <h1>Groceries: {{Groceries}}</h1> -->




</div>

</template>

<script>
import PlanService from "../services/PlanService";

export default {
  name: "grocery-list",
  data() {
    return {
      Groceries: []
    };
  },
  created() {
    PlanService.getGroceries(1).then((response) => {
      this.Groceries = response.data;


    });
  }
};
</script>

<style>


.table-heading{
  text-decoration: underline;
  
}
.table-list {
  padding: 20pv 20px;
  margin: 0 auto;
  max-width: 600px;
} 
.grocery-list {
 
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center flex-start;
  box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  border-radius: 5px;
  width: .5fr;
  
  margin: 5px 10px 5px 10px;
  padding: 0px 0px 0px 0px;
}



</style>
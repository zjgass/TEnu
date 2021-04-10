<template>
<div>

<h1>Grocery list for</h1>


<table>
  <!-- <tr>
    <th class='table-heading'>Item</th>
    <th class='table-heading'>Column 2</th>
        <th class='table-heading'>Column 3</th>
  </tr> -->
  <tr v-for='item in Groceries' 
v-bind:key='item.name'>
    <td>{{item.name}}</td>
    <td>{{item.qty}}</td>
      <td>{{item.unit}}</td>
  </tr>
</table>



<!-- <h1>Groceries: {{Groceries}}</h1> -->




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



</style>
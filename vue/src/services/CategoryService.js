import axios from 'axios';

let categoryPath = '/api/category';

export default {

  getCategories() {
    return axios.get(categoryPath);
  },

  getCategory(categoryId) {
    return axios.get(categoryPath + `/${categoryId}`)
  },

  addCategory(category) {
    return axios.post(categoryPath, category);
  },

  deleteCategory(categoryId){
    return axios.delete(categoryPath + `/${categoryId}`);
  }
}
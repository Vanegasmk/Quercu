<template>
  <div class="container mt-3">
    <div class="shadow-lg p-3 mb-5 bg-white rounded">
      <div class="card-header py-3 d-flex bd-highlight mb-3">
        <h5 class="m-0 font-weight-bold mr-auto p-2 bd-highlight">
          Property Types
        </h5>
        <router-link class="btn btn-primary ml-auto p-2 bd-highlight" to="/property-type/add">Add Property Type</router-link>
      </div>

      <div class="card-body">
        <div class="table-responsive">
          <table class="table table-bordered" width="100%" cellspacing="0">
            <thead>
              <tr>
                <th>Id</th>
                <th>Description</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(propertyType, index) of propertyTypes" :key="index">
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ propertyType.id }}
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ propertyType.description }}
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      <button type="button" class="btn btn-danger btn-sm" v-on:click="deletePropertyType(propertyType.id)">Delete</button>
                    </div>
                    <div class="p-2">
                      <router-link :to="{ name: 'UpdatePropertyType', params: { id: propertyType.id }}"  class="btn btn-warning btn-sm">Edit</router-link>
                    </div>
                  </div>
                </th>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data: () => ({
    apiUrl: "https://localhost:44384/PropertyType",
    propertyTypes: null,
  }),
  mounted() {
    this.getPropertyTypes();
  },
  methods: {
    async getPropertyTypes() {
      const data = await this.axios
        .get(this.apiUrl)
        .then((response) => (this.propertyTypes = response.data));
    },
    async deletePropertyType(id) {
      await this.axios.post(this.apiUrl + "/" + "Delete?id=" + id).
      then(() => this.getPropertyTypes());
    }
  },
};
</script>


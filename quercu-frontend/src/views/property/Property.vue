<template>
  <div class="mt-3 mx-5">
    <div class="shadow-lg p-3 mb-5 bg-white rounded">
      <div class="card-header py-3 d-flex bd-highlight mb-3">
        <h5 class="m-0 font-weight-bold mr-auto p-2 bd-highlight">
          Properties
        </h5>
        <router-link class="btn btn-primary ml-auto p-2 bd-highlight" to="/property/add">Add Property</router-link>
      </div>

      <div class="card-body">
        <div class="table-responsive">
          <table class="table table-bordered" >
            <thead>
              <tr>
                <th>Property Type</th>
                <th>Owner</th>
                <th>Number</th>
                <th>Address</th>
                <th>Area</th>
                <th>Construction Area</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(property, index) of properties" :key="index">
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ property.propertyType.description }}
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ property.owner.name }}  
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ property.number }}
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ property.address }}
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ property.area }} m²
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ property.constructionArea }} m²
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      <button type="button" class="btn btn-danger btn-sm" v-on:click="deleteProperty(property.id)">Delete</button>
                    </div>
                    <div class="p-2">
                      <router-link :to="{ name: 'UpdateProperty', params: { id: property.id }}"  class="btn btn-warning btn-sm">Edit</router-link>
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
    apiUrl: "https://localhost:44384/Property",
    properties: null,
  }),
  mounted(){
    this.getProperties();
  },
  methods: {
    async getProperties()
    {
      const data = await this.axios.get(this.apiUrl)
      .then(response => (this.properties = response.data));
      
    },
    async deleteProperty(id)
    {
      await this.axios.post(this.apiUrl + "/" + "Delete?id=" + id).
      then(() => this.getProperties());
    }
  }
}
</script>


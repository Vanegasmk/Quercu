<template>
  <div class="container mt-3">
    <div class="shadow-lg p-3 mb-5 bg-white rounded">
      <div class="card-header py-3 d-flex bd-highlight mb-3">
        <h5 class="m-0 font-weight-bold mr-auto p-2 bd-highlight">Owners</h5>
        <router-link class="btn btn-primary ml-auto p-2 bd-highlight" to="/owner/add">Add Owner</router-link>
      </div>

      <div class="card-body">
        <div class="table-responsive">
          <table class="table table-bordered" width="100%" cellspacing="0">
            <thead>
              <tr>
                <th>Name</th>
                <th>Telephone</th>
                <th>Email</th>
                <th>Identification</th>
                <th>Address</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(owner, index) of owners" :key="index">
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ owner.name }}
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ owner.telephone }}  
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ owner.email }}
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ owner.identificationNumber }}
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      {{ owner.address }} 
                    </div>
                  </div>
                </th>
                <th>
                  <div class="d-flex justify-content-center">
                    <div class="p-2">
                      <button type="button" class="btn btn-danger btn-sm" v-on:click="deleteOwner(owner.id)">Delete</button>
                    </div>
                    <div class="p-2">
                      <router-link :to="{ name: 'UpdateOwner', params: { id: owner.id }}"  class="btn btn-warning btn-sm">Edit</router-link>
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
    apiUrl: "https://localhost:44384/Owner",
    owners: null,
  }),
  mounted(){
    this.getOwners();
  },
  methods:{
    async getOwners() {
      const data = await this.axios
        .get("https://localhost:44384/Owner")
        .then((response) => (this.owners = response.data));
    },
    async deleteOwner(id) {
      await this.axios.post(this.apiUrl + "/" + "Delete?id=" + id).
      then(() => this.getOwners());
    }
  }
}
</script>
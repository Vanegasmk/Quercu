<template>
  <div class="container mt-3">
    <div class="shadow-lg p-3 mb-5 bg-white rounded">
      <div class="card-header py-3 d-flex bd-highlight mb-3">
        <h5 class="m-0 font-weight-bold mr-auto p-2 bd-highlight">
          Properties
        </h5>
        <a class="btn btn-primary ml-auto p-2 bd-highlight">Add Property</a>
      </div>

      <div class="card-body">
        <div class="table-responsive">
          <table class="table table-bordered" width="100%" cellspacing="0">
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
            <tbody></tbody>
          </table>
        </div>
      </div>
      
    </div>
  </div>
</template>

<script>
export default {};
</script>


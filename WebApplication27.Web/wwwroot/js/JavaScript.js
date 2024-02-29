$(() => {

    let count = 0
    $('#add-rows').on('click', function () {
        count++
        $('#ppl-rows').append(`
                                <div class="row person-row" style="margin-bottom: 10px;">
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" name="people[${count}].firstname" placeholder="First Name" />
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" name="people[${count}].lastname" placeholder="Last Name" />
                                    </div>
                                    <div class="col-md-4">
                                        <input class="form-control" type="text" name="people[${count}].age" placeholder="Age" />
                                    </div>
                                </div>
        `)
        console.log('hello')
    })



})
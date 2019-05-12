function excluir(id, nome) {
    // *****************************************************
    // Exemplo da funcção via JQuery

    // chamada em javascript
    //document.querySelector('#nomeProd').textContent = nome;
    //document.querySelector('#delProdModal').getAttribute('nome');

    // chamada via jquery
    $('#nomeProd').text(nome);

    $('#delProdModal')
        //.data('id', id) // ou com javascript //document.querySelector('#delProdModal').setAttribute('nome', id);
        .modal('show');

    _id = id;

    // ***************************************************
    // Exemplo da função excluir via javascript
    //let delProd = confirm(`Quer excluir o produto "${nome}"?`);

    //if (delProd) {
    //    let xhr = new XMLHttpRequest();

    //    xhr.onloadend = function () {
    //        //console.log(xhr.status, xhr);
    //        if (xhr.status == 200) {
    //            let tr = document.querySelector('#item-' + id);

    //            if (!!tr) tr.remove();

    //        } else {
    //            alert('Erro ao excluir o produto!');
    //        }
    //    }

    //    xhr.open('delete', 'http://localhost:49795/Produtos/Delete/' + id);
    //    xhr.send();
    //}

}

function confirmar() {
    //alert('Teste Ok!' + _id);
    // alert('ok - ' + $('#delProdModal').data('id'));
    // {} representa um objeto
    // Success => função de callback
    // @@ um aroba só é pra usar o razor
    // toaster aparece uns alertas estilizados e podem ser temporizados



    $.ajax({
        url: `${_url}/${_id}`, // interpolação de string usando crase
        type: 'delete',
        success: () => {
            toastr.success('Excluído com sucesso', 'FN Store');
            //document.querySelector('#item-' + _id).remove(); // JS
            $('#item-' + _id).remove(); // JQuery
        },
        error: data => toastr.error(data.responseText, 'FN Store'),
        complete: _ => $('#delProdModal').modal('hide')
    });
}
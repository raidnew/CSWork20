function removeContact(addr, idContact) {
    const formData = new FormData();
    formData.append("id", idContact);
    fetch(addr, {
        method: "DELETE",
        body: formData
    }).then(response => window.location.href = response.url)
}

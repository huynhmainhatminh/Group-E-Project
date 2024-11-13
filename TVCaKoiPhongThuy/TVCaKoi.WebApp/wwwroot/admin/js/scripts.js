function displayStats() {
    document.getElementById("total-members").textContent =22;
    document.getElementById("total-posts").textContent = 33;
}

// Xác định trang hiện tại và chạy hàm tương ứng
document.addEventListener("DOMContentLoaded", () => {
    if (document.getElementById("total-members")) displayStats();
    if (document.getElementById("member-list")) displayMembers();
    if (document.getElementById("post-list")) displayPosts();
});

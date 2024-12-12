<script>
    window.addEventListener('message', function(event) {
    if (event.data.height) {
        document.getElementById('myvideoresume').style.height = event.data.height + 'px';
    }
  }, false);
</script>
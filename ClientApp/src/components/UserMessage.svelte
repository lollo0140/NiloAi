<script>
    import { fly } from "svelte/transition";

    let { content } = $props();



</script>

<div in:fly={{y:20}} class="w-full">
    <div class="w-auto flex justify-center items-end flex-col">
        <p class="bg-[#E85002] p-1 pl-4 pr-4 rounded-[15px] font-bold">YOU</p>

        <p>{@html content}</p>
    </div>
</div>


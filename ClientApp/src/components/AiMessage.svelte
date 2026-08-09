<script>
    import { fly } from "svelte/transition";
    import { marked } from "marked";

    let { content } = $props();

    let htmlString = $derived(marked.parse(content))

</script>

<div in:fly={{y:20}} class="w-full ">
    <div class="w-auto flex justify-center items-start flex-col">
        <p class="bg-[#E85002] p-1 pl-4 pr-4 rounded-[15px] font-bold">NILO</p>

        <p>{@html htmlString}</p>
    </div>
</div>


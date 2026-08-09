<script>
    import AiMessage from "../components/AiMessage.svelte";
    import UserMessage from "../components/UserMessage.svelte";
    import { promptNilo } from "./requester";

    let value = $state("");

    let canType = $state(true);

    let chatElements = $state([
    ]);

    async function Prompt(message) {
        canType = false;

        const res = await promptNilo(message);
        chatElements.push({
            from: "ai",
            content: res,
        });
        
        value = "";
        canType = true;
    }
</script>

<div class="bg-black absolute inset-0 text-white overflow-y-scroll">
    <div class="flex flex-col ml-50 mr-50 gap-12.5 pb-37.5">
        {#each chatElements as e}
            {#if e.from === "user"}
                <UserMessage content={e.content} />
            {:else}
                <AiMessage content={e.content} />
            {/if}
        {/each}
    </div>
</div>

<div
    style={!canType ? "width: 52px;" : "width: 60%;"}
    class="border-white/9 border-2 rounded-[50px] fixed center"
>
    <div
        class="h-12 rounded-[50px] bg-[linear-gradient(45deg,#D9C3AB_0%,#F16001_30%,#C10801_65%,#D9C3AB_100%)]"
    >
        {#if canType}
            <div class="absolute inset-0.5 rounded-[50px] bg-black">
                <input
                    type="text"
                    bind:value
                    placeholder="Scrivi qualcos"
                    class="text-white outline-none absolute inset-0 left-4 right-32"
                />
                <button
                    class="bg-white absolute top-1 bottom-1 right-1 w-30 rounded-[50px]"
                    onclick={() => {
                        if (value != "") {
                            chatElements.push({
                                from: "user",
                                content: value,
                            });
                            Prompt(value);
                        }
                    }}>INVIA</button
                >
            </div>
        {:else}{/if}
    </div>
</div>

<style>
    * {
        transition: all 0.65s cubic-bezier(0.34, 1.56, 0.64, 1);
    }

    .center {
        left: 50%;
        transform: translateX(-50%);
        bottom: 50px;
    }
</style>

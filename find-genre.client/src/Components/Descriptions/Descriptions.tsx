import { Title, Text, Divider, useComputedColorScheme } from "@mantine/core";

function Descriptions({ descs, id }: { descs: string[], id: number }) {
    const scheme = useComputedColorScheme()
    const items = descs.map((item, i) => {
        if (i % 2 == 0) {
            return <Title key={id + item} id={item} c={scheme === 'dark' ? 'white' : 'black'}>{item}</Title>
        } else {
            return <Text key={id+item}>{item}</Text>
        }
})
    return (
        <>
            {items}
            <Divider my={32} />
        </>
  );
}

export default Descriptions;
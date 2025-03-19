import { Title, Text } from "@mantine/core";

function Descriptions({ descs, id }: { descs: string[], id:number }) {
    const items = descs.map((item, i) => {
        if (i % 2 == 0) {
            return <Title key={id + item} id={item}>{item}</Title>
        } else {
            return <Text key={id+item}>{item}</Text>
        }
})
    return (
        <>
            {items}
        </>
  );
}

export default Descriptions;
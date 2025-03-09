import { Stack, Title, Box, Group, Badge, Text, useComputedColorScheme, useMantineTheme } from "@mantine/core";
import { ISubgenre, ITag } from "../../Types/api";
import styles from './DetailsIntro.module.css'

function DetailsIntro({ name, desc, tags, subgenres }: { name: string, desc: string, tags: ITag[], subgenres: ISubgenre[] | undefined }) {
    const theme = useMantineTheme();
    const scheme = useComputedColorScheme();
    const bg_color = () => {
        return scheme == 'light' ? theme.colors.gray[3] : theme.colors.dark[8]
    }
  return (
      <Stack>
          <Title order={1}>{name}</Title>
          <Text>
              {desc}
          </Text>
          <Box bg={bg_color()} p={8} className={styles.container_radius}>
              <Title order={3} p={8}>Tags:</Title>
              <Group bd={"1px gray dashed"} p={8}>
                  {tags.map((element) => (
                      <Badge color="indigo" variant="light" key={element.tagId}>{element.name}</Badge>
                  ))}
              </Group>
          </Box>
          {subgenres && <Box bg={bg_color()} p={8} className={styles.container_radius}>
              <Title order={3} p={8}>Subgenres:</Title>
              <Group bd={"1px gray dashed"} p={8}>
                  {subgenres && subgenres.map((element) => (
                      <Badge key={element.subgenreId} color="indigo" variant="light">{element.name}</Badge>
                  ))}
              </Group>
          </Box>}
      </Stack>
  );
}

export default DetailsIntro;
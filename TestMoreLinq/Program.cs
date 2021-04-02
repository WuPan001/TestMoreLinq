using More = MoreLinq.MoreEnumerable;

//using MoreLinq;
using System;
using System.Collections.Generic;
using MoreLinq;
using System.Linq;
using System.Text;

namespace TestMoreLinq
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                //Acquire
                //Ensures that a source sequence of disposable objects are all acquired successfully.
                //If the acquisition of any one fails then those successfully acquired till that point are disposed.

                //Aggregate
                //Applies multiple accumulators sequentially in a single pass over a sequence.

                //This method has 7 overloads.
                //var tt=     More.Aggregate<byte>(data,1,()=> {  },2,()=> { },()=> { });
                //AggregateRight
                //Applies a right-associative accumulator function over a sequence.
                //This operator is the right - associative version of the Aggregate LINQ operator.

                //This method has 3 overloads.

                //Append
                //Returns a sequence consisting of the head element and the given tail elements.
                Print("Append", More.Append<byte>(data, 12));
                //Assert
                //Asserts that all elements of a sequence meet a given condition otherwise throws an exception.
                var tt = More.Assert(data, d => d > 4);
                var rr = data.Assert(d => d > 4);

                //This method has 2 overloads.

                //AssertCount
                //Asserts that a source sequence contains a given count of elements.

                //This method has 2 overloads.

                //AtLeast
                //Determines whether or not the number of elements in the sequence is greater than or equal to the given integer.
                Console.WriteLine($"AtLeast||{data.AtLeast(7)}");
                //AtMost
                //Determines whether or not the number of elements in the sequence is lesser than or equal to the given integer.
                Console.WriteLine($"AtMost||{data.AtMost(7)}");
                //Backsert
                //Inserts the elements of a sequence into another sequence at a specified index from the tail of the sequence,
                //where zero always represents the last position, one represents the second - last element,
                //two represents the third-last element and so on.
                //将一个序列插入到另一个序列中，插入位置由index的值确定，从待插入序列的末尾起数index个元素插入新序列
                Print("Backsert", data.Backsert(new byte[] { 56, 34 }, data.Length));
                //Batch
                //Batches the source sequence into sized buckets.
                //分组，分组的大小由size的值决定。最后一组数量小于size时，也不填充，剩多少个元素最后的组中就有多少个元素
                //This method has 2 overloads.
                var batch1 = data.Batch(3);
                foreach (var item in batch1)
                {
                    Print("Batch", item);
                }
                var batch2 = data.Batch(3, b => b.AtLeast(3));
                foreach (var item in batch2)
                {
                    Console.WriteLine($"Batch||{item}");
                }
                //Cartesian
                //Returns the Cartesian product of two or more sequences by combining each element from the sequences and applying a user - defined projection to the set.

                //This method has 7 overloads.

                //Choose
                //Applies a function to each element of the source sequence and returns a new sequence of result elements for source elements
                //where the function returns a couple(2 - tuple) having a true as its first element and result as the second.
                //对源序列的每个元素应用一个函数，并为源元素返回一个新的结果元素序列，其中函数返回一对(2元组)，第一个元素为true，第二个元素为result。
                //测试中并不是描述的那样
                //真实情况是，对源序列的每个元素应用一个函数，当Func返回的二元组中的第一个元素为true时，才返回第二个元素
                //对每个元素的操作不能用后置运算符
                var choose = data.Choose(d => (d >= 2, ++d));
                Print("Choose", choose);
                //CompareCount
                //Compares two sequences and returns an integer that indicates whether the first sequence has fewer,
                //the same or more elements than the second sequence.
                //当当前序列长度比第二个数列元素多时，返回1；相等时，返回0；少时，返回-1
                //Console.WriteLine($"CompareCount||{data.CompareCount(data.Append<byte>(123))}");
                //Concat
                //Returns a sequence consisting of the head element and the given tail elements.

                //This method is obsolete and will be removed in a future version.Use Append instead.

                //Consume
                //Completely consumes the given sequence.This method uses immediate execution, and doesn't store any data during execution

                //CountBetween
                //Determines whether or not the number of elements in the sequence is between an inclusive range of minimum and maximum integers.
                Console.WriteLine($"CountBetween||{data.CountBetween(data.Length - 1, data.Length + 1)}");
                //CountBy
                //Applies a key - generating function to each element of a sequence and returns a sequence of unique keys and their number of occurrences in the original sequence.
                //对序列中的每一个元素进行操作（例子中的d + 1）并计数，返回一个键值对序列，其中，键为元素值，值为元素值数量
                Print("CountBy", data.Backsert(new byte[] { 1, 1, 1, 1, 1 }, 0).CountBy(d => d + 1));
                //This method has 2 overloads.

                //CountDown
                //Provides a countdown counter for a given count of elements at the tail of the sequence where zero always represents the last element,
                //one represents the second - last element, two represents the third - last element and so on.
                Print("CountDown", data./*Backsert(new byte[] { 1, 1, 1, 1, 1 }, 0).*/CountDown(2, (_, d) => d));
                //DistinctBy
                //Returns all distinct elements of the given source,
                //where "distinctness" is determined via a projection and the default equality comparer for the projected type.

                //This method has 2 overloads.

                //EndsWith
                //Determines whether the end of the first sequence is equivalent to the second sequence.
                Console.WriteLine($"EndsWith||{data.EndsWith(data.Backsert(new byte[] { 123 }, 0))}");
                Print("EndsWith", data);
                Print("EndsWith", data.Backsert(new byte[] { 123 }, 0));
                //This method has 2 overloads.

                //EquiZip
                //Returns a projection of tuples, where each tuple contains the N - th element from each of the argument sequences.
                //An exception is thrown if the input sequences are of different lengths.

                //This method has 3 overloads.

                //Exactly
                //Determines whether or not the number of elements in the sequence is equals to the given integer.
                Console.WriteLine($"Exactly||{ data.Exactly(12)}");
                //ExceptBy
                //Returns the set of elements in the first sequence which aren't in the second sequence, according to a given key selector.
                //根据给定的键选择器，返回第一个序列中不属于第二个序列的元素集合。
                //如果是数组，那么key就是索引
                //如果设置了筛选函数，则只会返回第一个满足条件的元素；如果筛选函数为d => d，则返回全部符合条件的结果
                Print("ExceptBy", data.ExceptBy(new byte[] { 3 }, d => d > 6));
                //This method has 2 overloads.

                //Exclude
                //Excludes elements from a sequence starting at a given index
                //根据索引和数量排除原序列中的元素
                Print("Exclude", data.Exclude(2, 2));
                //FallbackIfEmpty
                //Returns the elements of a sequence and falls back to another if the original sequence is empty.

                //This method has 6 overloads.

                //FillBackward
                //Returns a sequence with each null reference or value in the source replaced
                //with the following non - null reference or value in that sequence.

                //This method has 3 overloads.

                //FillForward
                //Returns a sequence with each null reference or value in the source replaced
                //with the previous non - null reference or value seen in that sequence.

                //This method has 3 overloads.

                //Flatten
                //Flattens a sequence containing arbitrarily-nested sequences.

                //This method has 3 overloads.

                //Fold
                //Returns the result of applying a function to a sequence with 1 to 16 elements.

                //This method has 16 overloads.

                //ForEach
                //Immediately executes the given action on each element in the source sequence.

                //This method has 2 overloads.
                data.ForEach(d => Console.WriteLine(d));
                Print("ForEach", data);
                //From
                //Returns a sequence containing the values resulting from invoking (in order) each function in the source sequence of functions.

                //This method has 4 overloads.

                //FullGroupJoin
                //Performs a Full Group Join between the and sequences.

                //This method has 4 overloads.

                //FullJoin
                //Performs a full outer join between two sequences.

                //This method has 4 overloads.

                //Generate
                //Returns a sequence of values consecutively generated by a generator function
                Print("Generate", More.Generate(1, n => n + 2).TakeWhile(n => n < 10));
                //GenerateByIndex
                //Returns a sequence of values based on indexes
                ///方法参数为索引
                Print("GenerateByIndex", More.GenerateByIndex(n => n * 2).TakeWhile(n => n < 10));
                //GroupAdjacent
                //Groups the adjacent elements of a sequence according to a specified key selector function.

                //This method has 6 overloads.

                //Incremental
                //Incremental was redundant with Pairwise and so deprecated since version 2.1.It was eventually removed in version 3.0.

                //Index
                //Returns a sequence of where the key is the zero - based index of the value in the source sequence.

                //  This method has 2 overloads.
                //返回值为键值对序列，键为索引，值为原序列的元素值
                Print("Index", data.Index());
                //IndexBy
                //Applies a key-generating function to each element of a sequence and returns a sequence
                //that contains the elements of the original sequence as well its key and index inside the group of its key.
                //An additional argument specifies a comparer to use for testing equivalence of keys.

                //This method has 2 overloads.
                //返回一个键值对序列，值为原序列中的元素值，键根据keySelector的返回值在序列中的排序得到
                //例子中以第一个元素的第一个字符作为筛选，"ana"中第一次出现‘a’，所以键为0，"adriano"中第二次出现‘a’，所以键为1, "angelo"中第三次出现‘a’，所以键为2
                var source = new[] { "ana", "beatriz", "carla", "bob", "davi", "adriano", "angelo", "carlos" };
                var result = source.IndexBy(x => x.LastOrDefault());
                Print("IndexBy", result);
                //Insert
                //Inserts the elements of a sequence into another sequence at a specified index.
                //在指定索引处将序列的元素插入到另一个序列中
                Print("Insert", data.Insert(new byte[] { 123 }, 2));
                //Interleave
                //Interleaves the elements of two or more sequences into a single sequence, skipping sequences as they are consumed.
                //将两个或多个序列的元素交错到单个序列中，并在序列被消耗时跳过它们
                Print("Interleave", More.Interleave(data, new byte[] { 12, 12, 12 }));
                //Lag滞后
                //Produces a projection of a sequence by evaluating pairs of elements separated by a negative offset.
                //返回一个序列，将原序列中的每个元素减去一个值，小于等于0的元素用默认元素或者0填充
                //resultSelector中的第一个参数为原系列中的值，第二个参数为计算（滞后）后的值
                const int lagBy = 2;
                const byte lagDefault = 0;
                Print("Lag", data.Lag(lagBy, lagDefault, (val, lagVal) => lagVal));
                Print("Lag", data.Lag(lagBy, lagDefault, (val, lagVal) => lagVal - val));
                Print("Lag", data.Lag(lagBy, (val, lagVal) => lagVal + val));

                //This method has 2 overloads.

                //Lead
                //Produces a projection of a sequence by evaluating pairs of elements separated by a positive offset.
                //返回一个序列，将原序列中的每个元素加上一个值，大于等于原序列中的最大值的元素用默认元素或者0填充
                //resultSelector中的第一个参数为原系列中的值，第二个参数为计算（超前）后的值
                //This method has 2 overloads.
                const int leadBy = 2;
                const byte leadDefault = 100;
                Print("", data);
                Print("Lead", data.Lead(leadBy, leadDefault, (val, lagVal) => lagVal));
                Print("Lead", data.Lead(leadBy, leadDefault, (val, lagVal) => lagVal - val));
                Print("Lead", data.Lead(leadBy, (val, lagVal) => lagVal));
                //LeftJoin
                //Performs a left outer join between two sequences.

                //This method has 4 overloads.
                //MaxBy
                //Returns the maxima(maximal elements) of the given sequence, based on the given projection.
                //返回一个序列
                //This method has 2 overloads.
                Console.WriteLine($"MaxBy||{data.IndexBy(d => d).MaxBy(d => d.Value).FirstOrDefault()}");
                //MinBy
                //Returns the minima(minimal elements) of the given sequence, based on the given projection.
                //返回一个序列
                //This method has 2 overloads.
                Console.WriteLine($"MinBy||{data.IndexBy(d => d).MinBy(d => d.Value).FirstOrDefault()}");
                //Move
                //Returns a sequence with a range of elements in the source sequence moved to a new offset.

                Print("", data.Move(3, 3, 1));

                //OrderBy
                //Sorts the elements of a sequence in a particular direction(ascending, descending) according to a key.

                //This method has 2 overloads.
                Print("OrderBy", data.IndexBy(d => d).OrderBy(d => d.Value));
                Print("OrderByDescending", data.IndexBy(d => d).OrderByDescending(d => d.Value));
                //OrderedMerge
                //Merges two ordered sequences into one.Where the elements equal in both sequences,
                //the element from the first sequence is returned in the resulting sequence.
                //This method has 7 overloads.
                Print("OrderedMerge", data.OrderedMerge(data.Backsert(new byte[] { 123 }, 0)));
                Print("OrderedMerge", data.OrderedMerge(new byte[] { 12, 12, 12, 12 }));
                //Pad
                //Pads a sequence with default values if it is narrower(shorter in length) than a given width.
                //如果序列比给定的宽度更窄(长度更短)，则用默认值填充序列。
                //默认值为0或指定值
                //paddingSelector中的参数为元素的索引
                //This method has 3 overloads.
                Print("Pad", data.Pad(20));
                Print("Pad", data.Pad(20, (byte)123));
                Print("Pad", data.Pad(20, i => i % 2 == 0 ? (byte)23 : (byte)34));
                //PadStart
                //Pads a sequence with default values in the beginning if it is narrower(shorter in length) than a given width.
                //从原序列的开始开始填充元素
                //This method has 3 overloads.
                Print("PadStart", data.PadStart(20));
                Print("PadStart", data.PadStart(20, (byte)123));
                Print("PadStart", data.PadStart(20, i => i % 2 == 0 ? (byte)23 : (byte)34));
                //Pairwise
                //Returns a sequence resulting from applying a function to each element in the source sequence and its predecessor,
                //with the exception of the first element which is only returned as the predecessor of the second element
                //返回的序列长度比原序列长度小1
                //resultSelector中的第一个参数为原序列在当前索引下的元素值，第二个参数为原序列在当前索引+1下的元素的值
                Print("Pairwise", data);
                Print("Pairwise", data.Pairwise((one, two) =>
                {
                    Console.WriteLine(one);
                    Console.WriteLine(two);
                    return one * two;
                }));
                //PartialSort
                //Combines OrderBy(where element is key) and Take in a single operation.
                //部分排序
                //先排序后取值
                //This method has 4 overloads.
                Print("PartialSort", data.PartialSort(4));
                Print("PartialSort", data.PartialSort(4, OrderByDirection.Ascending));
                Print("PartialSort", data.PartialSort(4, OrderByDirection.Descending));
                //PartialSortBy
                //Combines OrderBy and Take in a single operation.
                //根据条件部分排序
                //先排序后取值
                //This method has 4 overloads.
                Print("PartialSortBy", data.IndexBy(d => d).PartialSortBy(5, d => d.Value));
                Print("PartialSortBy", data.IndexBy(d => d).PartialSortBy(5, d => d.Value, OrderByDirection.Descending));
                //Partition
                //Partitions a sequence by a predicate, or a grouping by Boolean keys or up to 3 sets of keys.
                //分组
                //This method has 10 overloads.
                var (part1, part2) = data.Partition(x => x % 2 == 0, (o, t) => Tuple.Create(new byte[] { 34, 45 }, new byte[] { 12 }));
                Print("Partition", part1);
                Print("Partition", part2);
                //Permutations
                //Generates a sequence of lists that represent the permutations of the original sequence
                //Print("Permutations", data.Permutations());
                //Pipe
                //Executes the given action on each element in the source sequence and yields it

                // The action will occur "in" the pipe, so by the time Where gets it, the
                // sequence will be empty.

                //Prepend
                //Prepends a single value to a sequence

                //PreScan
                //Performs a pre-scan(exclusive prefix sum) on a sequence of elements

                //Random
                //Returns an infinite sequence of random integers using the standard .NET random number generator.

                //This method has 6 overloads.

                //RandomDouble
                //Returns an infinite sequence of random double values between 0.0 and 1.0.

                //This method has 2 overloads.

                //RandomSubset
                //Returns a sequence of a specified size of random elements from the original sequence.

                //This method has 2 overloads.

                //Rank
                //Ranks each item in the sequence in descending ordering using a default comparer.

                //This method has 2 overloads.

                //RankBy
                //Ranks each item in the sequence in descending ordering by a specified key using a default comparer.

                //This method has 2 overloads.

                //Repeat
                //Repeats the sequence indefinitely or a specific number of times.

                //This method has 2 overloads.

                //Return
                //Returns a single-element sequence containing the item provided.

                //RightJoin
                //Performs a right outer join between two sequences.

                //This method has 4 overloads.

                //RunLengthEncode
                //Run - length encodes a sequence by converting consecutive instances of the same element into a KeyValuePair<T, int> representing the item and its occurrence count.

                //This method has 2 overloads.

                //Scan
                //Peforms a scan(inclusive prefix sum) on a sequence of elements.

                //This method has 2 overloads.

                //ScanBy
                //Applies an accumulator function over sequence element keys,
                //returning the keys along with intermediate accumulator states.

                //This method has 2 overloads.

                //ScanRight
                //Peforms a right-associative scan(inclusive prefix) on a sequence of elements.
                //This operator is the right - associative version of the Scan operator.

                //This method has 2 overloads.

                //Segment
                //Divides a sequence into multiple sequences by using a segment detector based on the original sequence.

                //This method has 3 overloads.

                //Sequence
                //Generates a sequence of integral numbers within the(inclusive) specified range.

                //This method has 2 overloads.

                //Shuffle
                //Returns a sequence of elements in random order from the original sequence.

                //This method has 2 overloads.

                //SkipLast
                //Bypasses a specified number of elements at the end of the sequence.

                //SkipUntil
                //Skips items from the input sequence until the given predicate returns true when applied to the current source item;
                //that item will be the last skipped

                //Slice
                //Extracts elements from a sequence at a particular zero - based starting index

                //SortedMerge
                //Merges two or more sequences that are in a common order(either ascending or descending) into a single sequence that preserves that order.

                //This method has 2 overloads.

                //Split
                //Splits the source sequence by a separator.

                //This method has 12 overloads.

                //StartsWith
                //Determines whether the beginning of the first sequence is equivalent to the second sequence.

                //This method has 2 overloads.

                //Subsets
                //Returns a sequence of representing all of the subsets of any size that are part of the original sequence.

                //This method has 2 overloads.

                //TagFirstLast
                //Returns a sequence resulting from applying a function to each element in the source sequence
                //with additional parameters indicating whether the element is the first and/ or last of the sequence

                //TakeEvery
                //Returns every N-th element of a source sequence

                //TakeLast
                //Returns a specified number of contiguous elements from the end of a sequence

                //TakeUntil
                //Returns items from the input sequence until the given predicate returns true
                //when applied to the current source item; that item will be the last returned

                //ThenBy
                //Performs a subsequent ordering of elements in a sequence in a particular direction(ascending, descending) according to a key.

                //This method has 2 overloads.

                //ToArrayByIndex
                //Creates an array from an IEnumerable where a function is used to determine the index at which an element will be placed in the array.

                //This method has 6 overloads.

                //ToDataTable
                //Appends elements in the sequence as rows of a given object with a set of lambda expressions specifying
                //which members(property or field) of each element in the sequence will supply the column values.

                //This method has 4 overloads.

                //ToDelimitedString
                //Creates a delimited string from a sequence of values.
                //The delimiter used depends on the current culture of the executing thread.

                //This method has 15 overloads.

                //ToDictionary
                //Creates a dictionary from a sequence of key - value pair elements or tuples of 2.

                //  This method has 4 overloads.

                //ToHashSet
                //Returns a hash-set of the source items using the default equality comparer for the type.

                //This method has 2 overloads.

                //ToLookup
                //Creates a lookup from a sequence of key - value pair elements or tuples of 2.

                //This method has 4 overloads.

                //Transpose
                //Transposes the rows of a sequence into columns.

                //TraverseBreadthFirst
                //Traverses a tree in a breadth - first fashion,
                //starting at a root node and using a user-defined function to get the children at each node of the tree.

                //TraverseDepthFirst
                //Traverses a tree in a depth-first fashion,
                //starting at a root node and using a user-defined function to get the children at each node of the tree.

                //Trace
                //Traces the elements of a source sequence for diagnostics.

                //This method has 3 overloads.

                //Unfold
                //Returns a sequence generated by applying a state to the generator function, and from its result,
                //determines if the sequence should have a next element and its value, and the next state in the recursive call.

                //Window
                //Processes a sequence into a series of subsequences representing a windowed subset of the original

                //Windowed
                //Processes a sequence into a series of subsequences representing a windowed subset of the original

                //This method is obsolete and will be removed in a future version.Use Window instead.

                //WindowLeft
                //Creates a left-aligned sliding window over the source sequence of a given size.

                //WindowRight
                //Creates a right-aligned sliding window over the source sequence of a given size.

                //ZipLongest
                //Returns a projection of tuples, where each tuple contains the N - th element from each of the argument sequences.
                //The resulting sequence will always be as long as the longest of input sequences
                //where the default value of each of the shorter sequence element types is used for padding.

                // This method has 3 overloads.

                // ZipShortest
                // Returns a projection of tuples, where each tuple contains the N - th element from each of the argument sequences.
                //The resulting sequence is as short as the shortest input sequence.

                // This method has 3 overloads.

                // Experimental Operators
                // THESE METHODS ARE EXPERIMENTAL.THEY MAY BE UNSTABLE AND UNTESTED.
                //THEY MAY BE REMOVED FROM A FUTURE MAJOR OR MINOR RELEASE AND POSSIBLY WITHOUT NOTICE.
                //USE THEM AT YOUR OWN RISK.
                //THE METHODS ARE PUBLISHED FOR FIELD EXPERIMENTATION TO SOLICIT FEEDBACK ON THEIR UTILITY AND DESIGN / IMPLEMENTATION DEFECTS.

                // Use of experimental methods requires importing the MoreLinq.Experimental namespace.

                // Aggregate
                //Applies multiple accumulator queries sequentially in a single pass over a sequence.

                //This method has 8 overloads.

                //Await
                //Creates a sequence query that streams the result of each task in the source sequence as it completes asynchronously.

                //This method has 2 overloads.

                //AwaitCompletion
                //Awaits completion of all asynchronous evaluations irrespective of whether they succeed or fail.
                //An additional argument specifies a function that projects the final result given the source item and completed task.

                //Memoize
                //Creates a sequence that lazily caches the source as it is iterated for the first time,
                //reusing the cache thereafter for future re-iterations.If the source is already cached or buffered then it is returned verbatim.

                //TrySingle
                //Returns the only element of a sequence that has just one element.If the sequence has zero or multiple elements,
                //then returns a user-defined value that indicates the cardinality of the result sequence.

                //This method has 2 overloads.
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }

        private static void Print<T>(string title, IEnumerable<T> data)
        {
            Console.Write($"{title}||");
            foreach (var item in data)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}